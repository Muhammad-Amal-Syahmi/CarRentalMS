using System;
using System.Linq;
using System.Threading.Tasks;
using CarRentalMS.DataAccess;
using CarRentalMS.DataAccess.Infrastructure.Interfaces;
using CarRentalMS.DataAccess.Repositories.Interfaces;
using CarRentalMS.Services.Interfaces;

namespace CarRentalMS.Services
{
    public class CarServices : ICarServices
    {
        IUnitOfWork _unitOfWork;
        ICarRepository _carRepository;

        public CarServices(IUnitOfWork unitOfWork, ICarRepository carRepository)
        {
            _unitOfWork = unitOfWork;
            _carRepository = carRepository;
        }

        public IQueryable<Car> GetAllCars(string carModel, string location)
        {
            if (!String.IsNullOrEmpty(carModel) ||
                !String.IsNullOrEmpty(location))
            {
                return _carRepository.GetCarsByFilter(carModel, location);
            }
            return _carRepository.GetAll();
        }

        public async Task AddCar(Car car)
        {
            if (car == null)
            {
                throw new ArgumentNullException("car");
            }
            car.Id= await _carRepository.GetNewId();
            _carRepository.Create(car);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<Car> FindCar(int? id)
        {
            return await _carRepository.FindById(id);
        }

        public async Task UpdateCar(Car car)
        {
            if (car == null)
                throw new ArgumentNullException("car");
            _carRepository.Update(car);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteCar(Car car)
        {
            if (car == null)
                throw new ArgumentNullException("car");
            _carRepository.Delete(car);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
