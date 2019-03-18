using System;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using CarRentalMS.DataAccess;
using CarRentalMS.ViewModels;

namespace CarRentalMS.Controllers
{
    public class AccountController : Controller
    {
        AWS_POSTGREQL_TRIALEntities dbContext = new AWS_POSTGREQL_TRIALEntities();

        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserAccountViewModel userVM)
        {
            if (ModelState.IsValid)
            {
                UserAccount userDM = new UserAccount();
                AutoMapper.Mapper.Map(userVM, userDM);
                var Acc = dbContext.UserAccounts.Where(x => x.UserName == userDM.UserName).FirstOrDefault();
                if (Acc != null && userDM.UserPassword == Decrypt(Acc.UserPassword))
                {
                    FormsAuthentication.SetAuthCookie(userDM.UserName, false); //Persistent Cookie
                    TempData["msgSuccess"] = "Log In";
                    return RedirectToAction("Index", "Home");
                }
            }
            //ViewBag.Msg = "Invalid User";
            TempData["msgFailed"] = "Log In";
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        // Encryption & Decryption

        private static readonly UTF8Encoding Encoder = new UTF8Encoding();

        public static string Encrypt(string unencrypted)
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

        public static string Decrypt(string encrypted)
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