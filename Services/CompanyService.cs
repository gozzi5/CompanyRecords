using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Services.Util;
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


        public async Task<ResponseObject<CompanyViewModel>> CreateCompany(CompanyViewModel companyVm)
        {

            ResponseObject<CompanyViewModel> responseObject = new ViewModels.ResponseObject<CompanyViewModel>();


            ////validating company
            var validation = CompanyValidation.ValidationForCompany(companyVm);

            if (!validation.Valid)
            {

                responseObject.Message = validation.Message;
                responseObject.Success = false;

                return responseObject;

            }

            // checking for duplicate isins
            var checkIsin = await _context.Company.FirstOrDefaultAsync(x => x.ISIN.ToLower() == companyVm.ISIN.ToLower());

            if (checkIsin != null)
            {


                responseObject.Message = "ISIN already exists";
                responseObject.Success = false;

                return responseObject;
            }


            Company company = MappingToCompany(companyVm);

            _context.Company.Add(company);
            await _context.SaveChangesAsync();

            responseObject.Result = MappingToViewModel(company);
            responseObject.Success = true;


            return responseObject;
        }
        public async Task<ResponseObject<CompanyViewModel>> GetCompanyByIsin(string isin)
        {
            ResponseObject<CompanyViewModel> responseObject = new ViewModels.ResponseObject<CompanyViewModel>();

            Company company = await _context.Company.FirstOrDefaultAsync(x => x.ISIN.ToLower() == isin.ToLower());

            if (company != null)
            {
                responseObject.Result = MappingToViewModel(company);
                responseObject.Success = true;
            }
            else
            {
                responseObject.Success = false;
                responseObject.Message = "Company not found";
            }

            return responseObject;
        }

        public async Task<ResponseObject<CompanyViewModel>> GetCompanyById(int id)
        {
            ResponseObject<CompanyViewModel> responseObject = new ViewModels.ResponseObject<CompanyViewModel>();


            Company company = await _context.Company.FirstOrDefaultAsync(x=>x.Id ==id);
            if (company != null)
            {
                responseObject.Result = MappingToViewModel(company);
                responseObject.Success = true;
            }
            else
            {

                responseObject.Success = false;
                responseObject.Message = "Company not found";

            }


            return responseObject;
        }

        public async Task<ResponseObjects<CompanyViewModel>> GetCompanys()
        {
            ResponseObjects<CompanyViewModel> responseObject = new ViewModels.ResponseObjects<CompanyViewModel>();
            List<Company> companys = await _context.Company.ToListAsync();

            if (companys != null)
            {

                responseObject.Results = MappingToListViewModel(companys);
                responseObject.Success = true;
            }
            else
            {

                responseObject.Success = false;
                responseObject.Message = "No Companies found";
            }

            return responseObject;
        }

        public async Task<ResponseObject<CompanyViewModel>> UpdateCompany(CompanyViewModel companyVm)
        {
            ResponseObject<CompanyViewModel> responseObject = new ViewModels.ResponseObject<CompanyViewModel>();

            Company company = _context.Company.Find(companyVm.Id);

            ////validating company
            var validation = CompanyValidation.ValidationForCompany(companyVm);

            if (!validation.Valid)
            {

                responseObject.Message = validation.Message;
                responseObject.Success = false;
                return responseObject;
            }

            // checking for duplicate isins
            var checkIsin = await _context.Company.FirstOrDefaultAsync(x => x.ISIN.ToLower() == companyVm.ISIN.ToLower() && x.Id != companyVm.Id);

            if (checkIsin != null)
            {


                responseObject.Message = "ISIN already exists";
                responseObject.Success = false;
                return responseObject;

            }

            if (company != null)
            {
                company.Name = companyVm.Name;
                company.Ticker = companyVm.Ticker;
                company.WebSite = companyVm.WebSite;
                company.Exchange = companyVm.Exchange;
                company.ISIN = companyVm.ISIN;


                _context.Update(company);

                await _context.SaveChangesAsync();
            }
            responseObject.Success = true;
            responseObject.Result = MappingToViewModel(company);

            return responseObject;
        }

        private Company MappingToCompany(CompanyViewModel companyVm)
        {


            return new Company
            {
                Id = companyVm.Id,
                ISIN = companyVm.ISIN,
                Ticker = companyVm.Ticker,
                Name = companyVm.Name,
                Exchange = companyVm.Exchange,
                WebSite = companyVm.WebSite
            };
        }
        private CompanyViewModel MappingToViewModel(Company company)
        {


            return new CompanyViewModel
            {
                Id = company.Id,
                ISIN = company.ISIN,
                Ticker = company.Ticker,
                Name = company.Name,
                Exchange = company.Exchange,
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
                    Id = company.Id,
                    ISIN = company.ISIN,
                    Ticker = company.Ticker,
                    Name = company.Name,
                    Exchange = company.Exchange,
                    WebSite = company.WebSite
                };
                companyViewModels.Add(companyVm);
            }

            return companyViewModels;
        }
    }
}
