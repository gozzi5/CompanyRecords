using DataAccess.Data;
using Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface  ICompanyService
    {
        Task<ResponseObject<CompanyViewModel>> CreateCompany(CompanyViewModel company);
        Task<ResponseObjects<CompanyViewModel>> GetCompanys();

        Task<ResponseObject<CompanyViewModel>> UpdateCompany(CompanyViewModel company);

        Task<ResponseObject<CompanyViewModel>> GetCompanyByIsin(string isin);

        Task<ResponseObject<CompanyViewModel>> GetCompanyById(int id);
    }
}
