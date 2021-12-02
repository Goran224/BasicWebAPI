using BasicWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicWebAPI
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Contact>()
                .HasOne(c => c.company)
                .WithMany(x => x.Contacs)
                .HasForeignKey(c => c.CompanyId);

            builder.Entity<Contact>()
               .HasOne(c => c.country)
               .WithMany(x => x.Contacs)
               .HasForeignKey(c => c.CountryId);
        }
    }
}

