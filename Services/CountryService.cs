using BasicWebAPI.DTOs;
using BasicWebAPI.Interfaces;
using BasicWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicWebAPI.Services
{
    public class CountryService : ICountryService
    {
        private readonly DataContext _datacontext;

        public CountryService(DataContext dataContext)
        {
            _datacontext = dataContext;
        }
        public Country CreateCountry(CountryInsertDto countryInsertDto)
        {
            var country = new Country();
            country.CountryName = countryInsertDto.CountryName;
            _datacontext.Countries.Add(country);
            _datacontext.SaveChanges();
            return country;
        }

        public void DeleteCountry(int id)
        {
            var country = _datacontext.Countries.Find(id);
            _datacontext.Countries.Remove(country);
            _datacontext.SaveChanges();
        }

        public List<Country> Get()
        {
            return _datacontext.Countries.ToList();
        }

        public void Update(int id, CountryInsertDto countryInsertDto)
        {
            var country = _datacontext.Countries.Find(id);
            country.CountryName = countryInsertDto.CountryName;
            _datacontext.SaveChanges();
        }
    }
}
