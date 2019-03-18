using System;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using CarRentalMS.DataAccess;
using CarRentalMS.DataAcess.Repositories.Interfaces;
using CarRentalMS.Services.Interfaces;

namespace CarRentalMS.Services
{
    public class AccountServices : IAccountServices
    {
        IAccountRepository _accountRepository;

        public AccountServices(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public bool Login(UserAccount user)
        {
            var Acc = _accountRepository.UserLogin(user);
            if (Acc != null && user.UserPassword == Decrypt(Acc.UserPassword))
            {
                return true;
            }
            return false;
        }

        public bool Logout()
        {
            throw new NotImplementedException();
        }

        // Encryption & Decryption
        private static readonly UTF8Encoding Encoder = new UTF8Encoding();

        private static string Encrypt(string unencrypted)
        {
            if (string.IsNullOrEmpty(unencrypted))
                return string.Empty;

            try
            {
                var encryptedBytes = MachineKey.Protect(Encoder.GetBytes(unencrypted));

                if (encryptedBytes != null && encryptedBytes.Length > 0)
                    return HttpServerUtility.UrlTokenEncode(encryptedBytes);
            }
            catch (Exception)
            {
                return string.Empty;
            }

            return string.Empty;
        }

        private static string Decrypt(string encrypted)
        {
            if (string.IsNullOrEmpty(encrypted))
                return string.Empty;

            try
            {
                var bytes = HttpServerUtility.UrlTokenDecode(encrypted);
                if (bytes != null && bytes.Length > 0)
                {
                    var decryptedBytes = MachineKey.Unprotect(bytes);
                    if (decryptedBytes != null && decryptedBytes.Length > 0)
                        return Encoder.GetString(decryptedBytes);
                }

            }
            catch (Exception)
            {
                return string.Empty;
            }

            return string.Empty;
        }
    }
}
