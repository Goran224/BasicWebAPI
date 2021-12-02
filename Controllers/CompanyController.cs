using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasicWebAPI.Interfaces;
using BasicWebAPI.DTOs;

namespace BasicWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {

        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService  = companyService;
        }

        [HttpGet]
        public IActionResult GetList()
        {
            return Ok(_companyService.Get());
        }

        [HttpPost("CreateCompany")]
        public IActionResult CreateCompany(CompanyInsertDto companyInsertDto)
        {
            _companyService.CreateCompany(companyInsertDto);

            return Ok("Successfully created");
        }

        [HttpDelete("{id}")]
        public void DeleteCompany(int id)
        {
            _companyService.DeleteCompany(id);

        }

        [HttpPut("Update Company {id}")]
        public IActionResult UpdateCompany(int id, CompanyInsertDto companyInsertDto)
        {
            _companyService.Update(id, companyInsertDto);
            return Ok("Successfully Updated");
        }
    }
}
