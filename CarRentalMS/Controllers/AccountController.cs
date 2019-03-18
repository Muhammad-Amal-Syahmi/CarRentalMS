using System.Web.Mvc;
using System.Web.Security;
using CarRentalMS.DataAccess;
using CarRentalMS.Services.Interfaces;
using CarRentalMS.ViewModels;

namespace CarRentalMS.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountServices _accountServices;

        public AccountController(IAccountServices accountServices)
        {
            _accountServices = accountServices;
        }

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

                var loginSuccess = _accountServices.Login(userDM);

                if (loginSuccess == true)
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


    }
}