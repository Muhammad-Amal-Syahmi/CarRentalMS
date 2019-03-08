using System;
using System.Linq;
using System.Threading.Tasks;
using CarRentalMS.DataAcess;
using CarRentalMS.DataAcess.Infrastructure.Interfaces;
using CarRentalMS.DataAcess.Repositories.Interfaces;
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

        public IQueryable<Car> GetAllCars()
        {
            return _carRepository.GetAll();
        }

        public async Task AddCar(Car car)
        {
            if (car == null)
            {
                throw new ArgumentNullException("car");
            }
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

        //public void Dispose()
        //{
        //}

        //private readonly AWS_POSTGREQL_TRIALEntities _dbContext = new AWS_POSTGREQL_TRIALEntities();

        //public async Task<IEnumerable<Car>> GetAllCars()
        //{
        //    return await _dbContext.Cars
        //        .OrderBy(c => c.Id)
        //        .Select(c => c).ToListAsync();
        //}

        //public async Task AddCar(Car car)
        //{
        //    int max = await _dbContext.Cars.MaxAsync(c => c.Id);
        //    car.Id = ++max;
        //    _dbContext.Cars.Add(car);
        //    await _dbContext.SaveChangesAsync();
        //}

        //public async Task<Car> FindCar(int? id)
        //{
        //    return await _dbContext.Cars.FindAsync(id);
        //}

        //public async Task UpdateCar(Car car)
        //{
        //    _dbContext.Entry(car).State = EntityState.Modified;
        //    await _dbContext.SaveChangesAsync();
        //}

        //public async Task DeleteCar(Car car)
        //{
        //    _dbContext.Cars.Remove(car);
        //    await _dbContext.SaveChangesAsync();
        //}

        //public void Dispose()
        //{
        //    _dbContext.Dispose();
        //}
    }
}
