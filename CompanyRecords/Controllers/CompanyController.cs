using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

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

        // GET: api/Company
        [HttpGet]
        public IActionResult  GetCompanies()
        {
            return Ok(new string[] { "value1", "value2" });
        }

        // GET: api/Company/5
        [HttpPost]
        public async Task<IActionResult> CreateCompany([FromBody]Company company)
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

        // POST: api/Company
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Company/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
