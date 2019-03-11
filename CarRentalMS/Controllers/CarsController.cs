using System.Collections.Generic;
using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using CarRentalMS.DataAccess;
using CarRentalMS.Services.Interfaces;
using CarRentalMS.ViewModels;

namespace CarRentalMS.Controllers
{
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
            var carDM = await _carServices.GetAllCars(
                SearchCarModel,
                SearchLocation).ToListAsync();
            IEnumerable<CarViewModel> carVM = new List<CarViewModel>();
            AutoMapper.Mapper.Map(carDM, carVM);
            return View(carVM);
        }

        // GET: Cars/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var carDM = await _carServices.FindCar(id);
            CarViewModel carVM = new CarViewModel();
            AutoMapper.Mapper.Map(carDM, carVM);
            if (carVM == null)
            {
                return HttpNotFound();
            }
            return View(carVM);
        }

        // GET: Cars/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cars/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CarModel,Location,PricePerDay")] CarViewModel carVM)
        {
            if (ModelState.IsValid)
            {
                Car carDM = new Car();
                AutoMapper.Mapper.Map(carVM, carDM);
                await _carServices.AddCar(carDM);
                return RedirectToAction("Index");
            }

            return View(carVM);
        }

        // GET: Cars/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car carDM = await _carServices.FindCar(id);
            CarViewModel carVM = new CarViewModel();
            AutoMapper.Mapper.Map(carDM, carVM);
            if (carVM == null)
            {
                return HttpNotFound();
            }
            return View(carVM);
        }

        // POST: Cars/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,CarModel,Location,PricePerDay")] CarViewModel carVM)
        {
            if (ModelState.IsValid)
            {
                Car carDM = new Car();
                AutoMapper.Mapper.Map(carVM, carDM);
                await _carServices.UpdateCar(carDM);
                return RedirectToAction("Index");
            }
            return View(carVM);
        }

        // GET: Cars/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car carDM = await _carServices.FindCar(id);
            CarViewModel carVM = new CarViewModel();
            AutoMapper.Mapper.Map(carDM, carVM);
            if (carVM == null)
            {
                return HttpNotFound();
            }
            return View(carVM);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Car car = await _carServices.FindCar(id);
            await _carServices.DeleteCar(car);
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        _carServices.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
