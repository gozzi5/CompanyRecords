using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services.Util;
using Services.ViewModels;

namespace CompanyRecordsTests
{
    [TestClass]
    public class CompanyValidationTest
    {
        [TestMethod]
        public void ValidationForCompanyShouldPass()
        {

            CompanyViewModel companyViewModel = new CompanyViewModel
            {
                ISIN = "US0378331005",
                Exchange = "NYSE",
                Ticker = "VOD LN",
                Name="Uber",
                WebSite = "www.company.com"
            };

            var actual =  CompanyValidation.ValidationForCompany(companyViewModel);

            Validation expection = new Validation
            {
                Valid = true
            };

            Assert.AreEqual(expection.Valid, actual.Valid);
        }
        [TestMethod]
        public void ValidationForCompanyShouldFailIncoreectIsin()
        {
            ///incorrect isin

            CompanyViewModel companyViewModel = new CompanyViewModel
            {
                ISIN = "US0378331",
                Exchange = "NYSE",
                Ticker = "VOD LN",
                Name = "Uber",
                WebSite = "www.company.com"
            };

            var actual = CompanyValidation.ValidationForCompany(companyViewModel);

            Validation expection = new Validation
            {
                Valid = false
            };

            Assert.AreEqual(expection.Valid, actual.Valid);
        }
        [TestMethod]
        public void ValidationForCompanyShouldFailMissingRequiredFields()
        {
           

            CompanyViewModel companyViewModel = new CompanyViewModel
            {
                ISIN = "US0378331",
                Exchange = "",
                Ticker = "VOD LN",
                Name = "",
                WebSite = "www.company.com"
            };

            var actual = CompanyValidation.ValidationForCompany(companyViewModel);

            Validation expection = new Validation
            {
                Valid = false
            };

            Assert.AreEqual(expection.Valid, actual.Valid);
        }
    }
}
