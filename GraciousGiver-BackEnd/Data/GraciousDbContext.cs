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
        public DbSet<Qyteti> Qyteti { get; set; }
        public DbSet<ProductCategory> ProductCategory { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductPhotos> ProductPhotos { get; set; }
        public DbSet<Shteti> Shteti { get; set; }
    }
}
