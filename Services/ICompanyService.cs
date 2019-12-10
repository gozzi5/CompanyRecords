using DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface  ICompanyService
    {
        Task<Company> CreateCompany(Company company);
            IEnumerable<Company> GetCompanys();

            IEnumerable<Company> UpdateCompany(Company company);

         Task<Company> GetCompanyByIsin(string isin);

            IEnumerable<Company> GetCompanyById(int id);
    }
}
