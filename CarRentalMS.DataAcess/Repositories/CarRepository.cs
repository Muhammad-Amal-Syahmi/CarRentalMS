using System;
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

        public async Task<int> GetNewId()
        {
            int max = await DbContext.Cars.MaxAsync(c => c.Id);
            return incrementIntByOne(max);
        }

        public static int incrementIntByOne(int value)
        {
            if (value == int.MaxValue)
            {
                throw new ArgumentException("Maximum value of id cannot be increment", "NewId");
            }
            return ++value;
        }
    }
}
