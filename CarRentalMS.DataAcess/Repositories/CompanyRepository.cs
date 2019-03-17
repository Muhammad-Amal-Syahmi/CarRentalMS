using System;
using System.Linq;
using System.Threading.Tasks;
using CarRentalMS.DataAccess;
using CarRentalMS.DataAccess.Infrastructure;
using CarRentalMS.DataAccess.Infrastructure.Interfaces;
using CarRentalMS.DataAccess.Repositories.Interfaces;

namespace CarRentalMS.DataAccess.Repositories
{
    public class CompanyRepository : GenericRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(IDbFactory dbFactory) : base(dbFactory) { }

        public IQueryable<Company> GetCompaniesByFilter(string companyName)
        {
            return DbContext.Set<Company>().
                Where(c =>
                    c.CompanyName.ToLower().Contains(companyName.ToLower())
                )
                //.OrderByDescending(c => c.LastModifiedDate)
                .AsQueryable();
        }

        public Task<int> GetMaxId()
        {
            throw new NotImplementedException();
        }
    }
}
