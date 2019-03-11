using System;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using CarRentalMS.DataAccess;

namespace CarRentalMS.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserAccount user)
        {
            AWS_POSTGREQL_TRIALEntities dbContext = new AWS_POSTGREQL_TRIALEntities();
            var Acc = dbContext.UserAccounts.Where(x => x.UserName == user.UserName).FirstOrDefault();
            if(user.UserPassword == Decrypt(Acc.UserPassword))
            {
                FormsAuthentication.SetAuthCookie(user.UserName, false); //Persistent Cookie
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Msg = "Invalid User";
            return View();
            //if (count == 0)
            //{
            //    ViewBag.Msg = "Invalid User";
            //    return View();
            //}
            //else
            //{
            //    FormsAuthentication.SetAuthCookie(user.UserName, false); //Persistent Cookie
            //    return RedirectToAction("Index", "Home");
            //}
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