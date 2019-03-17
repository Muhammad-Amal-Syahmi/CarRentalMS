using System;
using System.Linq;
using System.Threading.Tasks;
using CarRentalMS.DataAccess;
using CarRentalMS.DataAccess.Infrastructure.Interfaces;
using CarRentalMS.DataAccess.Repositories.Interfaces;
using CarRentalMS.Services.Interfaces;

namespace CarRentalMS.Services
{
    public class CompanyServices : ICompanyServices
    {
        IUnitOfWork _unitOfWork;
        ICompanyRepository _companyRepository;

        public CompanyServices(IUnitOfWork unitOfWork, ICompanyRepository companyRepository)
        {
            _unitOfWork = unitOfWork;
            _companyRepository = companyRepository;
        }

        public IQueryable<Company> GetAllCompanies(string SearchCompanyName)
        {
            if (!String.IsNullOrEmpty(SearchCompanyName))
            {
                var result = _companyRepository.GetCompaniesByFilter(SearchCompanyName);
                return result;
            }
            return _companyRepository.GetAll();
        }

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
