using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicWebAPI.Models
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }

        public ICollection<Contact> Contact { get; set; }


    }
}
