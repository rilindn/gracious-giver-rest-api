using GraciousGiver_BackEnd.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraciousGiver_BackEnd.Data
{
    public class GraciousDbContext : DbContext
    {
        public GraciousDbContext(DbContextOptions<GraciousDbContext> options) : base(options)
        {
        }
        public DbSet<City> City { get; set; }
        public DbSet<ProductCategory> ProductCategory { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductPhotos> ProductPhotos { get; set; }
        public DbSet<RequestPhotos> RequestPhotos { get; set; }
        public DbSet<Shteti> Shteti { get; set; }
        public DbSet<Street> Street { get; set; }
        public DbSet<Product_Request> Product_Request { get; set; }
        public DbSet<OrganizationCategory> OrganizationCategory { get; set; }
        public DbSet<Request> Request { get; set; }
        public DbSet<Bookmark> Bookmark { get; set; }
        public DbSet<ProductRequestResponse> ProductRequestResponse { get; set; }
        public DbSet<Organization> Organization { get; set; }
        public DbSet<OfferedProductResponse> OfferedProductResponse { get; set; }
        public DbSet<OfferProduct> OfferProduct { get; set; }
        public DbSet<PendingOrganizationsRequest> PendingOrganizationsRequest { get; set; }
        public DbSet<Notifications> Notifications { get; set; }
        public DbSet<OrganizationMember> OrganizationMember { get; set; }
        public DbSet<OrganizationMemberRequest> OrganizationMemberRequest { get; set; }
        public DbSet<Events> Events { get; set; }
        public DbSet<EventParticipants> EventParticipants { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Chat> Chat { get; set; }
        public DbSet<ChatMsg> ChatMsg { get; set; }
        public DbSet<Iniciative> Iniciative { get; set; }
        public DbSet<InitiativeRequest> InitiativeRequest { get; set; }
        public DbSet<Donation> Donation { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity => { entity.HasIndex(e => e.UserName).IsUnique(); });
        }
    }
}
