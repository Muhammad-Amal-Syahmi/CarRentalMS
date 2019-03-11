using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentalMS.DataAccess.Infrastructure.Interfaces;
using CarRentalMS.DataAccess;

namespace CarRentalMS.DataAccess.Repositories.Interfaces
{
    public interface ICarRepository : IGenericRepository<Car>
    {
        IQueryable<Car> GetCarsByFilter(string carModel, string location);
        Task<int> GetNewId();
    }
}
