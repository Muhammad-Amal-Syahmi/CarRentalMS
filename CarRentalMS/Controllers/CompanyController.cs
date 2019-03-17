using System.Linq;
using System.Web.Mvc;
using CarRentalMS.DataAccess;

namespace CarRentalMS.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CompanyController : Controller
    {
        AWS_POSTGREQL_TRIALEntities db = new AWS_POSTGREQL_TRIALEntities();
        // GET: Company
        public ActionResult Index()
        {
            var companies = db.Companies.ToList();
            return View(companies);
        }

        // GET: Company/Details/5
        public ActionResult Details(int id)
        {
            var company = db.Companies.Find(id);
            if (company == null)
            {
                return RedirectToAction("NotFound", "Error");
            }
            return PartialView(company);
        }

        // GET: Company/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Company/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Company/Edit/5
        public ActionResult Edit(int id)
        {
            var company = db.Companies.Find(id);
            if (company == null)
            {
                return RedirectToAction("NotFound", "Error");
            }
            return PartialView(company);
        }

        // POST: Company/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Company/Delete/5
        public ActionResult Delete(int id)
        {
            var company = db.Companies.Find(id);
            if (company == null)
            {
                return RedirectToAction("NotFound", "Error");
            }
            return PartialView(company);
        }

        // POST: Company/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
