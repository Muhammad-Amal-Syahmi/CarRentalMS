using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using CarRentalMS.DataAcess;

namespace CarRentalMS.Controllers
{
    public class CarsController : Controller
    {
        private AWS_POSTGREQL_TRIALEntities db = new AWS_POSTGREQL_TRIALEntities();

        // GET: Cars
        public async Task<ActionResult> Index()
        {

            IQueryable<Car> qrySearch = db.Cars
                .OrderBy(car => car.Id)
                .Select(car => car);


            return View(await qrySearch.ToListAsync());
        }
        //public async Task<ActionResult> Index(string searchCarModel, string searchLocation, int? page)
        //{
        //    if (searchCarModel == null)
        //    {
        //        searchCarModel = "";
        //    }
        //    if (searchLocation == null)
        //    {
        //        searchLocation = "";
        //    }

        //    IQueryable<Car> qrySearch = db.Cars
        //        .Where(car =>
        //            car.CarModel.ToLower().Contains(searchCarModel.ToLower())
        //            &&
        //            car.Location.ToLower().Contains(searchLocation.ToLower())
        //        )
        //        .OrderBy(car => car.Id)
        //        .Select(car => car)
        //        ;
        //    var qryAsync = await qrySearch.ToListAsync();

        //    return View(qryAsync.ToPagedList(page ?? 1, 10));
        //}

        // GET: Cars/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = await db.Cars.FindAsync(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // GET: Cars/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CarModel,Location,PricePerDay")] Car car)
        {
            if (ModelState.IsValid)
            {
                int max = await db.Cars.MaxAsync(c => c.Id);
                car.Id = ++max;
                db.Cars.Add(car);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(car);
        }

        // GET: Cars/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = await db.Cars.FindAsync(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,CarModel,Location,PricePerDay")] Car car)
        {
            if (ModelState.IsValid)
            {
                db.Entry(car).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(car);
        }

        // GET: Cars/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = await db.Cars.FindAsync(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Car car = await db.Cars.FindAsync(id);
            db.Cars.Remove(car);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
