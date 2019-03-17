using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentalMS.DataAccess;
using CarRentalMS.Services.Interfaces;

namespace CarRentalMS.Services
{
    public class CompanyServices : ICompanyServices
    {
        public Task AddCompany(Company car)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCompany(Company car)
        {
            throw new NotImplementedException();
        }

        public Task<Car> FindCompany(int? id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Company> GetAllCompanies()
        {
            throw new NotImplementedException();
        }

        public DateTime? GetCurrentDate()
        {
            throw new NotImplementedException();
        }

        public Task UpdateCompany(Company car)
        {
            throw new NotImplementedException();
        }
    }
}
