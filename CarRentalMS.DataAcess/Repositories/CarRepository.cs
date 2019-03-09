using System.Linq;
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
    }
}
