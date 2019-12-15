using DataAccess;
using DataAccess.Data;
using GenFu;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Services;
using Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CompanyRecordsTests
{
    [TestClass]
    public class CompanyServiceTest
    {
        private async Task<CompanyRecordsDBContext> CreateDbContext(string name)
        {
            var options = new DbContextOptionsBuilder<CompanyRecordsDBContext>()
                
          .UseInMemoryDatabase(databaseName: name)
          .Options;

            var context = new CompanyRecordsDBContext(options);

            var companies = GetFakeData();
            await context.AddRangeAsync(companies);
            await context.SaveChangesAsync();

            return context;
        }
        private List<Company> GetFakeData()
        {

            Company company = new Company
            {
                ISIN = "US0378331005",
                Exchange = "NYSE",
                Ticker = "VOD LN",
                Name = "Uber",
                WebSite = "www.company.com"
            };

            Company company2 = new Company
            {
                ISIN = "US0378331405",
                Exchange = "NYSE",
                Ticker = "VODs LN",
                Name = "Uber",
                WebSite = "www.company.com"
            };


            List<Company> companyViewModels = new List<Company>
            {
                company,
                company2
            };


            return companyViewModels;
        }
        [TestMethod]
        public async Task GetCompanies()
        {

            var context = await CreateDbContext("getCompanies");
            
            var service = new CompanyService(context);

            // act
            var results = await service.GetCompanys();
            var count =  results.Results.Count();
            // assert
            Assert.AreEqual(2, count);
        }
        [TestMethod]
        public async Task CreateCompanyTestShouldPass()
        {
            CompanyViewModel company2 = new CompanyViewModel
            {
                ISIN = "RU0378331405",
                Exchange = "NYSE",
                Ticker = "VODs LN",
                Name = "Uber",
                WebSite = "www.company.com"
            };
            var context = await CreateDbContext("createCompany");

            var service = new CompanyService(context);

         
            await service.CreateCompany(company2);

            var results = await service.GetCompanys();

            var count = results.Results.Count();
            
            Assert.AreEqual(3, count);
        }
        [TestMethod]
        public async Task UpdateCompanyTestShouldPass()
        {
            CompanyViewModel updateCompany = new CompanyViewModel
            {
                Id =1,
                ISIN = "RU0378331405",
                Exchange = "LSGE",
                Ticker = "VODs LN",
                Name = "Uber",
                WebSite = "www.company.com"
            };


            var context = await CreateDbContext("updateCompany");

            var service = new CompanyService(context);
           
            await service.UpdateCompany(updateCompany);

            var result = await service.GetCompanyById(1);

            
            Assert.AreEqual("LSGE", result.Result.Exchange);
        }
    }


}
