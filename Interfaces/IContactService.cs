using BasicWebAPI.DTOs;
using BasicWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicWebAPI.Interfaces
{
    public interface IContactService
    {
        public Contact CreateContact(ContactInsertDto countryInsertDto);
        public List<Contact> Get();
        public void DeleteContact(int id);

        public void Update(int id, ContactInsertDto contactInsertDto);

        public Task<List<Contact>> GetContactsWithCompanyAndCountry();


    }
}
