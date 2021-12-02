using BasicWebAPI.DTOs;
using BasicWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicWebAPI.Interfaces
{
   public  interface ICountryService
    {
        public Country CreateCountry(CountryInsertDto countryInsertDto);
        public List<Country> Get();
        public void DeleteCountry(int id);

        public void Update(int id, CountryInsertDto countryInsertDto);
    }
}
