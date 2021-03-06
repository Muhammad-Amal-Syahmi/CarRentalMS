﻿using System;
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

        public virtual async Task AddCompany(Company company)
        {
            if (company == null)
            {
                throw new ArgumentNullException("addCompany");
            }
            company.CompanyId = await GetNewId();
            _companyRepository.Create(company);
            await _unitOfWork.SaveChangesAsync();
        }

        public virtual async Task UpdateCompany(Company company)
        {
            if (company == null)
                throw new ArgumentNullException("updateCompany");
            _companyRepository.Update(company);
            await _unitOfWork.SaveChangesAsync();
        }

        public virtual async Task DeleteCompany(Company company)
        {
            if (company == null)
                throw new ArgumentNullException("deleteCompany");
            _companyRepository.Delete(company);
            await _unitOfWork.SaveChangesAsync();
        }

        public virtual async Task<Company> FindCompany(int? id)
        {
            var company = await _companyRepository.FindById(id);
            if (company.CompanyName == null)
                return null;
            return company;
        }

        public DateTime? GetCurrentDate()
        {
            throw new NotImplementedException();
        }

        private async Task<int> GetNewId()
        {
            var maxId = await _companyRepository.GetMaxId();
            return ++maxId;
        }
    }
}
