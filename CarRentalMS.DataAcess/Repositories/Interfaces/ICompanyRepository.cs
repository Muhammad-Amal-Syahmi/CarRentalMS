using System.Linq;
using System.Threading.Tasks;
using CarRentalMS.DataAccess;

namespace CarRentalMS.DataAcess.Repositories.Interfaces
{
    public interface ICompanyRepository
    {
        IQueryable<Company> GetCarsByFilter(string companyName);
        Task<int> GetMaxId();
    }
}
