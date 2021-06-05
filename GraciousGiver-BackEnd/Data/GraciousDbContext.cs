using GraciousGiver_BackEnd.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraciousGiver_BackEnd.Data
{
    public class GraciousDbContext: DbContext
    {
        public GraciousDbContext(DbContextOptions<GraciousDbContext> options ): base (options)
        {
        }
        public DbSet<City> City { get; set; }
        public DbSet<ProductCategory> ProductCategory { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductPhotos> ProductPhotos { get; set; }
        public DbSet<Shteti> Shteti { get; set; }
        public DbSet<Street> Street { get; set; }
        public DbSet<GG_Admin> GG_Admin { get; set; }

        public DbSet<DM_User> DM_User { get; set; }
    }
}
