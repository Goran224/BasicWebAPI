using BasicWebAPI.DTOs;
using BasicWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicWebAPI.Interfaces
{
  public  interface ICompanyService
    {
        public Company CreateCompany(CompanyInsertDto companyInsertDto);
        public List<Company> Get();
        public void DeleteCompany(int id);

        public void Update(int id, CompanyInsertDto companyInsertDto);
    }
}
