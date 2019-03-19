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
    [AllowAnonymous]
    public class CarsController : Controller
    {
        private readonly ICarServices _carServices;

        public CarsController(ICarServices carServices)
        {
            _carServices = carServices;
        }

        // GET: Cars
        public async Task<ActionResult> Index(string SearchCarModel, string SearchLocation)
        {
            try
            {
                var carDM = await _carServices.GetAllCars(
                SearchCarModel,
                SearchLocation).ToListAsync();
                IEnumerable<CarViewModel> carVM = new List<CarViewModel>();
                AutoMapper.Mapper.Map(carDM, carVM);
                return View(carVM);
            }
            catch (Exception)
            {
                return RedirectToAction("NotFound", "Error");
            }
        }

        // GET: Cars/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("NotFound", "Error");
            }
            var carDM = await _carServices.FindCar(id);
            CarViewModel carVM = new CarViewModel();
            AutoMapper.Mapper.Map(carDM, carVM);
            if (carVM == null)
            {
                return RedirectToAction("NotFound", "Error");
            }
            return PartialView("Details", carVM);

        }

        // GET: Cars/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cars/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CarModel,Location,PricePerDay")] CarViewModel carVM, bool AddAnotherCheckbox)
        {
            carVM.LastModifiedDate = _carServices.GetCurrentDate();
            if (ModelState.IsValid)
            {
                Car carDM = new Car();
                AutoMapper.Mapper.Map(carVM, carDM);
                await _carServices.AddCar(carDM);
                TempData["msgSuccess"] = "Car Added";
                if (AddAnotherCheckbox == true)
                {
                    TempData["Checkbox"] = true;
                    return RedirectToAction("Create");
                }
                return RedirectToAction("Index");
            }
            TempData["msgFailed"] = "Add Car";
            return View(carVM);
        }

        // GET: Cars/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("NotFound", "Error");
            }
            Car carDM = await _carServices.FindCar(id);
            CarViewModel carVM = new CarViewModel();
            AutoMapper.Mapper.Map(carDM, carVM);
            if (carVM == null)
            {
                return RedirectToAction("NotFound", "Error");
            }
            return View(carVM);
        }

        // POST: Cars/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,CarModel,Location,PricePerDay")] CarViewModel carVM)
        {
            carVM.LastModifiedDate = _carServices.GetCurrentDate();
            if (ModelState.IsValid)
            {
                Car carDM = new Car();
                AutoMapper.Mapper.Map(carVM, carDM);
                await _carServices.UpdateCar(carDM);
                TempData["msgSuccess"] = "Car Edited";
                return RedirectToAction("Index");
            }
            return View(carVM);
        }

        // GET: Cars/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("NotFound", "Error");
            }
            Car carDM = await _carServices.FindCar(id);
            CarViewModel carVM = new CarViewModel();
            AutoMapper.Mapper.Map(carDM, carVM);
            if (carVM == null)
            {
                return RedirectToAction("NotFound", "Error");
            }
            return PartialView("Delete", carVM);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Car car = await _carServices.FindCar(id);
            await _carServices.DeleteCar(car);
            TempData["msgSuccess"] = "Car Deleted";
            return RedirectToAction("Index");
        }
    }
}
