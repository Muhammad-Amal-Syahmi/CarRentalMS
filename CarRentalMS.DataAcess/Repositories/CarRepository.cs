using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using CarRentalMS.DataAccess.Infrastructure;
using CarRentalMS.DataAccess.Infrastructure.Interfaces;
using CarRentalMS.DataAccess.Repositories.Interfaces;

namespace CarRentalMS.DataAccess.Repositories
{
    public class CarRepository : GenericRepository<Car>, ICarRepository
    {
        public CarRepository(IDbFactory dbFactory) : base(dbFactory) { }

        public IQueryable<Car> GetCarsByFilter(string carModel, string location)
        {
            return DbContext.Set<Car>().
                Where(c =>
                    c.CarModel.ToLower().Contains(carModel.ToLower())
                    &&
                    c.Location.ToLower().Contains(location.ToLower())
                )
                .OrderBy(c => c.Id)
                .AsQueryable();
        }

        //public async Task<Car> FindCarById(int? id)
        //{
        //    //return await DbContext.Set<Car>().FindAsync(id);
        //    var obj= await (from car in DbContext.Cars
        //                 join company in DbContext.Companies on car.CompanyId equals company.CompanyId
        //                 where car.Id == id
        //                 select new { Id= car.Id, CarModel= car.CarModel, Location= car.Location, PricePerDay= car.PricePerDay}).FirstOrDefaultAsync();
        //    return obj;
        //}

        public async Task<int> GetMaxId()
        {
            return await DbContext.Cars.MaxAsync(c => c.Id);
        }
    }
}
