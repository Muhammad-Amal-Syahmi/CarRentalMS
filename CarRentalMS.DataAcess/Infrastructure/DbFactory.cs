using System;
using CarRentalMS.DataAccess.Infrastructure.Interfaces;
using CarRentalMS.DataAccess;

namespace CarRentalMS.DataAccess.Infrastructure
{
    public class DbFactory : IDbFactory
    {
        AWS_POSTGREQL_TRIALEntities _dbContext;

        public AWS_POSTGREQL_TRIALEntities Init()
        {
            return _dbContext ?? (_dbContext = new AWS_POSTGREQL_TRIALEntities());
        }

        public void Dispose()
        {
            if (_dbContext != null)
                _dbContext.Dispose();
        }
    }
}
