using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using CarRentalMS.DataAcess;
using CarRentalMS.Services.Interfaces;

namespace CarRentalMS.Services
{
    public class CarServices : ICarServices
    {
        private readonly AWS_POSTGREQL_TRIALEntities _dbContext = new AWS_POSTGREQL_TRIALEntities();

        public async Task<IEnumerable<Car>> GetAllCars()
        {
            return await _dbContext.Cars
                .OrderBy(c => c.Id)
                .Select(c => c).ToListAsync();
        }

        public async Task AddCar(Car car)
        {
            int max = await _dbContext.Cars.MaxAsync(c => c.Id);
            car.Id = ++max;
            _dbContext.Cars.Add(car);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Car> FindCar(int? id)
        {
            return await _dbContext.Cars.FindAsync(id);
        }

        public async Task UpdateCar(Car car)
        {
            _dbContext.Entry(car).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteCar(Car car)
        {
            _dbContext.Cars.Remove(car);
            await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
