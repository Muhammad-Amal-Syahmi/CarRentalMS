using System.Web.Mvc;
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
        public ActionResult Login(UserAccountViewModel userVM, bool stayLogin)
        {
            if (ModelState.IsValid)
            {
                UserAccount userDM = new UserAccount();
                AutoMapper.Mapper.Map(userVM, userDM);

                var loginSuccess = _accountServices.Login(userDM, stayLogin);

                if (loginSuccess == true)
                {
                    TempData["msgSuccess"] = "Log In";
                    return RedirectToAction("Index", "Home");
                }
            }
            TempData["msgFailed"] = "Log In";
            return View();
        }

        public ActionResult Logout()
        {
            var logoutSuccess = _accountServices.Logout();
            if (logoutSuccess)
            {
                TempData["msgSuccess"] = "Log Out";
                return RedirectToAction("Index", "Home");
            }
            TempData["msgFailed"] = "Log Out";
            return View();
        }


    }
}