﻿using BasicWebAPI.Models;
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

            public DbSet<Company> Companies { get; set; }

            public DbSet<Country> Countries { get; set; }
        }
    }
