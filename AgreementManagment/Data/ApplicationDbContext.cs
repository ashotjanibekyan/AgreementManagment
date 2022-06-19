using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AgreementManagment.Models;

namespace AgreementManagment.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Group>(entity =>
            {
                entity.HasIndex(e => e.Code).IsUnique();
            });
            builder.Entity<Group>().HasData(
                new Group
                {
                    Id = 1,
                    Active = true,
                    Code = "this is group code #1",
                    Description = "this is group description #1",
                },
                new Group
                {
                    Id = 2,
                    Active = false,
                    Code = "this is group code #2",
                    Description = "this is group description #2"
                },
                new Group
                {
                    Id = 3,
                    Active = false,
                    Code = "this is group code #3",
                    Description = "this is group description #3"
                },
                new Group
                {
                    Id = 4,
                    Active = false,
                    Code = "this is group code #4",
                    Description = "this is group description #4"
                });
            builder.Entity<Product>(entity =>
            {
                entity.HasIndex(e => e.Number).IsUnique();
            });

            builder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Active = true,
                    Description = "This is product description #1",
                    Number = 42,
                    Price = 42
                },
                new Product
                {
                    Id = 2,
                    Active = true,
                    Description = "This is product description #2",
                    Number = 43,
                    Price = 423
                },
                new Product
                {
                    Id = 3,
                    Active = true,
                    Description = "This is product description #4",
                    Number = 4233,
                    Price = 4123
                },
                new Product
                {
                    Id = 4,
                    Active = true,
                    Description = "This is product description #5",
                    Number = 4983,
                    Price = 4223
                });

            builder.Entity<Agreement>();
            base.OnModelCreating(builder);
        }

        public DbSet<Agreement>? Agreement { get; set; }
        public DbSet<Product>? Products { get; set; }
        public DbSet<Group>? Groups { get; set; }
    }
}