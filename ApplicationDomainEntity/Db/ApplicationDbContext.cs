using ApplicationDatabaseModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomainEntity.Db
{
    public class ApplicationDbContext : IdentityDbContext<User,UserRole,string>
    {
        public ApplicationDbContext() { }

        public DbSet<Clothe> Clothes { get; set; }
        public DbSet<Food> Food { get; set; }
        public DbSet<Furniture> Furnitures { get; set; }
        public DbSet<Technique> Techniques { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data source=DESKTOP-UR28SV7;Database=cartapp;Trusted_Connection=true;MultipleActiveResultSets=true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>()
                        .HasMany<Product>(s => s.Cart)
                        .WithMany(c => c.UsersCart);

        }

    }
}
