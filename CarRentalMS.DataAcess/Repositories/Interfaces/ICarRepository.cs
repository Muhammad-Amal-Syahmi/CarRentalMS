using System.Linq;
using System.Threading.Tasks;
using CarRentalMS.DataAccess.Infrastructure.Interfaces;

namespace CarRentalMS.DataAccess.Repositories.Interfaces
{
    public interface ICarRepository : IGenericRepository<Car>
    {
        IQueryable<Car> GetCarsByFilter(string carModel, string location);
        Task<int> GetMaxId();
        //int incrementIntByOne(int value);
    }
}
