using System;
using System.Linq;
using System.Threading.Tasks;
using CarRentalMS.DataAccess;

namespace CarRentalMS.Services.Interfaces
{
    public interface ICompanyServices
    {
        IQueryable<Company> GetAllCompanies(string SearchCompanyName);
        Task AddCompany(Company company);
        Task UpdateCompany(Company company);
        Task DeleteCompany(Company company);
        Task<Car> FindCompany(int? id);
        DateTime? GetCurrentDate();
    }
}
