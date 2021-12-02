using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BasicWebAPI.Models
{
    public class Contact
    {
        public int ContactId { get; set; }
        public string ContactName { get; set; }

       
        public int? CompanyId { get; set; }
        public int? CountryId { get; set; }

       [ForeignKey("CompanyId")]
        public virtual Company company { get; set; }

       [ForeignKey("CompanyId")]
        public virtual Country country { get; set; }
    }
}
