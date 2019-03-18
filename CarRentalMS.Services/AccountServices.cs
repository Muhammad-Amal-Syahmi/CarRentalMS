using System.Security.Cryptography;
using System.Text;
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

        public bool Login(UserAccount user, bool stayLogin)
        {
            var passwordHash = GetMD5Hash(user.UserPassword);
            var account = _accountRepository.UserLogin(user);
            if (account != null && passwordHash == account.UserPassword)
            {
                if (stayLogin == true)
                {
                    FormsAuthentication.SetAuthCookie(account.UserName, true); //Persistent Cookie
                }
                else
                {
                    FormsAuthentication.SetAuthCookie(account.UserName, false); //Non-Persistent Cookie
                }
                return true;
            }
            return false;
        }

        public bool Logout()
        {
            try
            {
                FormsAuthentication.SignOut();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Password Hashing
        private static string GetMD5Hash(string input)
        {
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] b = Encoding.UTF8.GetBytes(input);
                b = md5.ComputeHash(b);
                StringBuilder sb = new StringBuilder();

                foreach (byte x in b)
                {
                    sb.Append(x.ToString("x2"));
                }
                return sb.ToString();
            }
        }

    }
}
