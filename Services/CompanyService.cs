using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    public class CompanyService : ICompanyService
    {
        protected readonly CompanyRecordsDBContext _context;

        public CompanyService(CompanyRecordsDBContext context)
        {
            _context = context;

        }
        public IEnumerable<Company> GetCompanyById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Company> CreateCompany(Company company) {

           
            _context.Company.Add(company);
             await _context.SaveChangesAsync();

            return company;
        }
        public async Task<Company> GetCompanyByIsin(string isin)
        {
            

           return await _context.Company.FindAsync(isin);
            
        }

        public IEnumerable<Company> GetCompanys()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Company> UpdateCompany(Company company)
        {
            throw new NotImplementedException();
        }
    }
}
