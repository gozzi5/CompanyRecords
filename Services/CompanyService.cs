using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Services.ViewModels;

namespace Services
{
    public class CompanyService : ICompanyService
    {
        protected readonly CompanyRecordsDBContext _context;

        public CompanyService(CompanyRecordsDBContext context)
        {
            _context = context;

        }
      

        public async Task<CompanyViewModel> CreateCompany(CompanyViewModel companyVm) {

            Company company =  MappingToCompany(companyVm);

            _context.Company.Add(company);
             await _context.SaveChangesAsync();

            return MappingToViewModel(company);
        }
        public async Task<CompanyViewModel> GetCompanyByIsin(string isin)
        {

            Company company = await _context.Company.FindAsync();

            return MappingToViewModel(company);
        }

        public async Task<CompanyViewModel> GetCompanyById(int id)
        {

            Company company = await _context.Company.FindAsync(id);

            return MappingToViewModel(company);
        }

        public async Task<List<CompanyViewModel>> GetCompanys()
        {
            List<Company> companys = await _context.Company.ToListAsync();


            return MappingToListViewModel(companys);
        }

        public  void UpdateCompany(CompanyViewModel companyVm)
        {

          Company company =  _context.Company.Find(companyVm.Id);

            if (company != null)
            {
                _context.Update(company);

                _context.SaveChanges();
            }
        }

        private  Company  MappingToCompany(CompanyViewModel companyVm) {


            return  new Company
            {
                ISIN = companyVm.ISIN,
                Ticker = companyVm.Ticker,
                Name = companyVm.Name,
                WebSite = companyVm.WebSite
            };
        }
        private CompanyViewModel MappingToViewModel(Company company)
        {


            return new CompanyViewModel
            {
                ISIN = company.ISIN,
                Ticker = company.Ticker,
                Name = company.Name,
                WebSite = company.WebSite
            };
        }

        private List<CompanyViewModel> MappingToListViewModel(List<Company> companys)
        {
            List<CompanyViewModel> companyViewModels = new List<CompanyViewModel>();
            foreach (var company in companys)
            {
                CompanyViewModel companyVm = new CompanyViewModel
                {
                    ISIN = company.ISIN,
                    Ticker = company.Ticker,
                    Name = company.Name,
                    WebSite = company.WebSite
                };
                companyViewModels.Add(companyVm);
            }

            return companyViewModels;
        }
    }
}
