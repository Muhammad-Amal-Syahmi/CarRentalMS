using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalMS.DataAcess.Infrastructure.Interfaces
{
    public interface IGenericRepository<T> where T: class
    {
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        IQueryable<T> GetAll();
        Task<T> FindById(int? id);
    }
}
