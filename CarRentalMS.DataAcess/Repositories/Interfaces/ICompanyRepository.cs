using System.Linq;
using System.Threading.Tasks;
using CarRentalMS.DataAccess;
using CarRentalMS.DataAccess.Infrastructure.Interfaces;

namespace CarRentalMS.DataAccess.Repositories.Interfaces
{
    public interface ICompanyRepository : IGenericRepository<Company>
    {
        IQueryable<Company> GetCompaniesByFilter(string companyName);
        Task<int> GetMaxId();
    }
}
