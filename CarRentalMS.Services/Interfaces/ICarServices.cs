using System.Linq;
using System.Threading.Tasks;
using CarRentalMS.DataAcess;

namespace CarRentalMS.Services.Interfaces
{
    public interface ICarServices
    {
        IQueryable<Car> GetAllCars();
        Task AddCar(Car car);
        Task UpdateCar(Car car);
        Task DeleteCar(Car car);
        Task<Car> FindCar(int? id);
    }
}
