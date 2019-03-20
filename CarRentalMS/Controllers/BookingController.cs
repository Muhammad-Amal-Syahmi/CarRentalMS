using System.Web.Mvc;

namespace CarRentalMS.Controllers
{
    [Authorize(Roles = "User")]
    public class BookingController : Controller
    {
        // GET: Booking
        public ActionResult Index()
        {
            return View();
        }
    }
}