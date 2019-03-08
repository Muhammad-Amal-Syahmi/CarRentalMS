using CarRentalMS.DataAcess.Infrastructure;
using CarRentalMS.DataAcess.Infrastructure.Interfaces;
using CarRentalMS.DataAcess.Repositories.Interfaces;

namespace CarRentalMS.DataAcess.Repositories
{
    public class CarRepository : GenericRepository<Car>, ICarRepository
    {
        public CarRepository(IDbFactory dbFactory) : base(dbFactory) { }
    }
}
