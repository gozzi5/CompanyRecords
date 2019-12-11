using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.ViewModels;

namespace CompanyRecords.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public  CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
            
        }

        /// <summary>
        /// /Get companies
        /// </summary>
        /// <returns>list of companies</returns>
        [HttpGet]
        public async Task<IActionResult> GetCompanies()
        {

            try
            {
                var companies  = await _companyService.GetCompanys();

                return Ok(companies);
            }
            catch (Exception e) {

                throw e;

            }
           
        }

       /// <summary>
       /// Creates a Company
       /// </summary>
       /// <param name="company"></param>
       /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateCompany([FromBody]CompanyViewModel company)
        {
            try
            {
                await _companyService.CreateCompany(company);

                return Ok(company);
            }
            catch (Exception e) {

                throw e;
            }

            
        }


        /// <summary>
        /// Update company
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        [HttpPut]
        public IActionResult UpdateCompany([FromBody] CompanyViewModel company)
        {
            try
            {

                _companyService.UpdateCompany(company);

                return Ok();
            }
            catch (Exception e)
            {

                throw e;
            }
        }

       /// <summary>
       /// Get CompanyById
       /// </summary>
       /// <param name="id"></param>
       /// <returns>Company</returns>
        [HttpGet]
        public async Task<IActionResult> GetCompanyById(int id)
        {
            try
            {

             var company =  await _companyService.GetCompanyById(id);

             return Ok(company);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        /// <summary>
        /// Gets Company isin string
        /// </summary>
        /// <param name="isin"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetCompanyById(string isin)
        {
            try
            {
                var company = await _companyService.GetCompanyByIsin(isin);

                return Ok(company);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
