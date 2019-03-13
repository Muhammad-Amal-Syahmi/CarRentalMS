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
                var result = _carRepository.GetCarsByFilter(carModel, location);
                return result;
            }
            return _carRepository.GetAll();
        }

        public virtual async Task AddCar(Car car)
        {
            if (car == null)
            {
                throw new ArgumentNullException("addCar");
            }
            car.Id = await GetNewId();
            _carRepository.Create(car);
            await _unitOfWork.SaveChangesAsync();
        }

        public virtual async Task<Car> FindCar(int? id)
        {
            var car = await _carRepository.FindById(id);
            if (car.CarModel == null)
                return null;
            return car;
        }

        public async Task UpdateCar(Car car)
        {
            if (car == null)
                throw new ArgumentNullException("updateCar");
            _carRepository.Update(car);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteCar(Car car)
        {
            if (car == null)
                throw new ArgumentNullException("deleteCar");
            _carRepository.Delete(car);
            await _unitOfWork.SaveChangesAsync();
        }

        private async Task<int> GetNewId()
        {
            var maxId = await _carRepository.GetMaxId();
            return ++maxId;
        }
    }
}
