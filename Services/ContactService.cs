using BasicWebAPI.DTOs;
using BasicWebAPI.Interfaces;
using BasicWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicWebAPI.Services
{
    public class ContactService : IContactService
    {
        private readonly DataContext _datacontext;

        public ContactService(DataContext dataContext)
        {
            _datacontext = dataContext;
        }
        public async Task<Contact> CreateContact(ContactInsertDto contactInsertDto)
        {
            var contact = new Contact();
            contact.ContactName = contactInsertDto.ContactName;
            contact.CompanyId = contactInsertDto.CompanyId;
            contact.CountryId = contactInsertDto.CountryId;
            contact.company = _datacontext.Companies.Find(contactInsertDto.CompanyId);
            contact.country = _datacontext.Countries.Find(contactInsertDto.CountryId);
            _datacontext.Contacts.Add(contact);
            _datacontext.SaveChanges();
            return contact;
        }

        public void DeleteContact(int id)
        {
            var contact = _datacontext.Contacts.Find(id);
            _datacontext.Contacts.Remove(contact);
            _datacontext.SaveChanges();
        }

        public List<Contact> Get()
        {
            return _datacontext.Contacts.ToList();
        }

        public async Task<List<Contact>> GetContactsWithCompanyAndCountry()
        {
            return null;
   
       }

        public void Update(int id, ContactInsertDto contactInsertDto)
        {
            var contact = _datacontext.Contacts.Find(id);
           contact.ContactName = contactInsertDto.ContactName;
            contact.CompanyId = contactInsertDto.CompanyId;
            contact.CountryId = contactInsertDto.CountryId;
            contact.country = _datacontext.Countries.Find(contactInsertDto.CountryId);
            contact.company = _datacontext.Companies.Find(contactInsertDto.CompanyId);
            _datacontext.SaveChanges();
        }
    }
}
