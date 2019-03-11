using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentalMS.DataAccess.Infrastructure.Interfaces;
using CarRentalMS.DataAccess;

namespace CarRentalMS.DataAccess.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private AWS_POSTGREQL_TRIALEntities _dbContext;
        private readonly IDbFactory _dbFactory;
        public AWS_POSTGREQL_TRIALEntities DbContext
        {
            get { return _dbContext ?? (_dbContext = _dbFactory.Init()); }
        }

        public UnitOfWork(IDbFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public void SaveChanges()
        {
            DbContext.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await DbContext.SaveChangesAsync();
        }
    }
}
