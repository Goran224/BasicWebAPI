
using BasicWebAPI.DTOs;
using BasicWebAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicWebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {

        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet]
        public IActionResult GetList()
        {
            return Ok(_countryService.Get());
        }

        [HttpPost("CreateCountry")]
        public IActionResult CreateCompany(CountryInsertDto companyInsertDto)
        {
            _countryService.CreateCountry(companyInsertDto);

            return Ok("Successfully created");
        }

        [HttpDelete("{id}")]
        public void DeleteCountry(int id)
        {
            _countryService.DeleteCountry(id);

        }

        [HttpPut("Update Country {id}")]
        public IActionResult UpdateCountry(int id, CountryInsertDto countryInsertDto)
        {
            _countryService.Update(id, countryInsertDto);
            return Ok("Successfully Updated");
        }
    }
}
