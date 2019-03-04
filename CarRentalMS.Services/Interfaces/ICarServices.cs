using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentalMS.DataAcess;

namespace CarRentalMS.Services.Interfaces
{
    public interface ICarServices
    {
        Task<IEnumerable<Car>> GetAllCars();
        Task AddCar(Car car);
        Task UpdateCar(Car car);
        Task DeleteCar(Car car);
        Task<Car> FindCar(int? id);
        void Dispose();
    }
}
