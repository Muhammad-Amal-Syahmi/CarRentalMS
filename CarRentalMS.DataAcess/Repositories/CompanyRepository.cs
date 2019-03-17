using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentalMS.DataAccess;
using CarRentalMS.DataAcess.Repositories.Interfaces;

namespace CarRentalMS.DataAcess.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        public IQueryable<Company> GetCarsByFilter(string companyName)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetMaxId()
        {
            throw new NotImplementedException();
        }
    }
}
