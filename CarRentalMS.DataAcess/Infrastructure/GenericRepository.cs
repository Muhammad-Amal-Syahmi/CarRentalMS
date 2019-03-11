using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using CarRentalMS.DataAccess.Infrastructure.Interfaces;
using CarRentalMS.DataAccess;

namespace CarRentalMS.DataAccess.Infrastructure
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private AWS_POSTGREQL_TRIALEntities dbContext;
        protected readonly IDbSet<T> _dbSet;
        protected IDbFactory _dbFactory { get; private set; }
        protected AWS_POSTGREQL_TRIALEntities DbContext
        {
            get { return dbContext ?? (dbContext = _dbFactory.Init()); }
        }

        public GenericRepository(IDbFactory dbFactory)
        {
            _dbFactory = dbFactory;
            _dbSet = DbContext.Set<T>();
        }

        public void Create(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task<T> FindById(int? id)
        {
            return await DbContext.Set<T>().FindAsync(id);
        }

        public IQueryable<T> GetAll()
        {
            return DbContext.Set<T>().AsQueryable();
        }

        public void Update(T entity)
        {
            DbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
