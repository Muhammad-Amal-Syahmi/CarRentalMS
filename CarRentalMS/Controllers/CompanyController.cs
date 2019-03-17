using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Mvc;
using CarRentalMS.DataAccess;
using CarRentalMS.Services.Interfaces;
using CarRentalMS.ViewModels;

namespace CarRentalMS.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CompanyController : Controller
    {
        AWS_POSTGREQL_TRIALEntities db = new AWS_POSTGREQL_TRIALEntities();

        private readonly ICompanyServices _companyServices;

        public CompanyController(ICompanyServices companyServices)
        {
            _companyServices = companyServices;
        }

        // GET: Company
        public async Task<ActionResult> Index(string SearchCompanyName)
        {
            try
            {
                List<Company> companyDM = await _companyServices.GetAllCompanies(
                    SearchCompanyName).ToListAsync();
                IEnumerable<CompanyViewModel> companyVM = new List<CompanyViewModel>();
                AutoMapper.Mapper.Map(companyDM, companyVM);
                return View(companyVM);
            }
            catch (Exception)
            {
                return RedirectToAction("NotFound", "Error");
            }
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
        public async Task<ActionResult> Create([Bind(Include = "CompanyName,CompanyEmail")] CompanyViewModel companyVM, bool AddAnotherCheckbox)
        {
            //try
            //{
            //    // TODO: Add insert logic here

            //    return RedirectToAction("Index");
            //}
            //catch
            //{
            //    return View();
            //}

            //carVM.LastModifiedDate = _carServices.GetCurrentDate();
            if (ModelState.IsValid)
            {
                Company companyDM = new Company();
                AutoMapper.Mapper.Map(companyVM, companyDM);
                await _companyServices.AddCompany(companyDM);
                TempData["msgSuccess"] = "Company Added";
                if (AddAnotherCheckbox == true)
                {
                    return RedirectToAction("Create");
                }
                return RedirectToAction("Index");
            }
            TempData["msgFailed"] = "Add Company";
            return View(companyVM);
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
