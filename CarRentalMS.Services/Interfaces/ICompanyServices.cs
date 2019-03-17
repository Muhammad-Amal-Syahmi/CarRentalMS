using System;
using System.Linq;
using System.Threading.Tasks;
using CarRentalMS.DataAccess;

namespace CarRentalMS.Services.Interfaces
{
    public interface ICompanyServices
    {
        IQueryable<Company> GetAllCompanies();
        Task AddCompany(Company car);
        Task UpdateCompany(Company car);
        Task DeleteCompany(Company car);
        Task<Car> FindCompany(int? id);
        DateTime? GetCurrentDate();
    }
}
