﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CategoryProductManagement.Models
{
    public class AppDbContext:DbContext
    {
        //public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        //{

        //}
        public DbSet<Category> categories { get; set; }
        public DbSet<Product> products { get; set; }

        public AppDbContext() : base("myconn") { }
    }
}