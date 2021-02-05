using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class CarRentalContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = VLIKCCPC,InitialCatalog = CarRental,Trusted_Connection=True");
        }
        public DbSet <Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<CarColor> Colors { get; set; }
    }
}
