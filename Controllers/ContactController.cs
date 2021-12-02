using BasicWebAPI.DTOs;
using BasicWebAPI.Interfaces;
using BasicWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {

        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public IActionResult GetList()
        {
            return Ok(_contactService.Get());
        }

        [HttpGet("WiwthCountryAndCompany")]
        public async Task<List<Contact>> GetWithCountryAndCompany()
        {
            return await _contactService.GetContactsWithCompanyAndCountry();
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