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
        Task<CompanyViewModel> CreateCompany(CompanyViewModel company);
        Task<List<CompanyViewModel>> GetCompanys();

        void UpdateCompany(CompanyViewModel company);

        Task<CompanyViewModel> GetCompanyByIsin(string isin);

        Task<CompanyViewModel> GetCompanyById(int id);
    }
}
