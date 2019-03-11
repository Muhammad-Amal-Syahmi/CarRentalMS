using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using CarRentalMS.DataAcess.Infrastructure;
using CarRentalMS.DataAcess.Infrastructure.Interfaces;
using CarRentalMS.DataAcess.Repositories.Interfaces;

namespace CarRentalMS.DataAcess.Repositories
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

        public async Task<int> GetNewId()
        {
            int max = await DbContext.Cars.MaxAsync(c => c.Id);
            return ++max; 
        }
    }
}
