using System.Web.Mvc;

namespace CarRentalMS.Controllers
{
    public class ErrorController : Controller
    {
        [AllowAnonymous]
        public ActionResult NotFound(string aspxerrorpath)
        {
            if (!string.IsNullOrWhiteSpace(aspxerrorpath))
                return RedirectToAction("NotFound");

            return View();
        }
    }
}