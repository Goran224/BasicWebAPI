using BasicWebAPI.DTOs;
using BasicWebAPI.Interfaces;
using BasicWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly DataContext _datacontext;
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService, DataContext dataContext)
        {
            _contactService = contactService;
            _datacontext = dataContext;
        }

        [HttpGet]
        public IActionResult GetList()
        {
            return Ok(_contactService.Get());
        }

        [HttpGet("WithCountryAndCompany")]
        public async Task<IEnumerable> GetWith()
        {
            var mydata =  await _datacontext.Contacts.Join(_datacontext.Companies,
                p => p.CompanyId,
                pm => pm.CompanyId,
                (p, pm) => new { p, pm })
                .Join(_datacontext.Countries,
                ppm => ppm.p.CountryId,
                p => p.CountryId,
                (ppm, p) => new { ppm, p})
                .Select(result => new
                {
                    result.ppm.p.ContactName,
                    result.p.CountryName,
                    result.ppm.pm.CompanyName,
                    
                }).ToListAsync();

            return mydata;
        }

        [HttpPost("CreateContact")]
        public IActionResult CreateCompany(ContactInsertDto contactInsertDto)
        {
            _contactService.CreateContact(contactInsertDto);

            return Ok("Successfully created");
        }

        [HttpDelete("{id}")]
        public void DeleteContact(int id)
        {
            _contactService.DeleteContact(id);

        }

        [HttpPut("Update Contact {id}")]
        public IActionResult UpdateContact(int id, ContactInsertDto contactInsertDto)
        {
            _contactService.Update(id, contactInsertDto);
            return Ok("Successfully Updated");
        }
    }
}