using BasicWebAPI.DTOs;
using BasicWebAPI.Interfaces;
using BasicWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicWebAPI.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly DataContext _datacontext;

        public CompanyService(DataContext dataContext)
        {
            _datacontext = dataContext;
        }
        public Company CreateCompany(CompanyInsertDto companyInsertDto)
        {
            var company = new Company();
            company.CompanyName = companyInsertDto.CompanyName;
            _datacontext.Add(company);
            _datacontext.SaveChanges();
            return company;
        }

        public void DeleteCompany(int id)
        {
            var company = _datacontext.Companies.Find(id);
            _datacontext.Companies.Remove(company);
            _datacontext.SaveChanges();
        }

        public List<Company> Get()
        {
            return _datacontext.Companies.ToList();
        }

        public void Update(int id, CompanyInsertDto companyInsertDto)
        {
            var company = _datacontext.Companies.Find(id);
            company.CompanyName = companyInsertDto.CompanyName;
            _datacontext.SaveChanges();
        }
    }
}
