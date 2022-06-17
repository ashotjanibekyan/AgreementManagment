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
            builder.Entity<Product>(entity =>
            {
                entity.HasIndex(e => e.Number).IsUnique();
            });
            builder.Entity<Agreement>();
            base.OnModelCreating(builder);
        }

        public DbSet<Agreement>? Agreement { get; set; }
        public DbSet<Product>? Products { get; set; }
        public DbSet<Group>? Groups { get; set; }
    }
}