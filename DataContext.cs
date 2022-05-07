using BasicWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicWebAPI
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Company> Companies { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);



            builder.Entity<Country>().HasMany(c => c.Contact)
                .WithOne(c => c.Country).HasForeignKey(f => f.CountryId);

            builder.Entity<Company>().HasMany(c => c.Contact)
                .WithOne(c => c.Company).HasForeignKey(f => f.CompanyId);

            builder.Entity<Contact>()
                .HasOne(c => c.Country)
                .WithMany(co => co.Contact)
                .HasForeignKey(ur => ur.CountryId)
                .IsRequired();

            builder.Entity<Contact>()
               .HasOne(c => c.Company)
               .WithMany(co => co.Contact)
               .HasForeignKey(com => com.CompanyId)
               .IsRequired();

        }
    }
}

