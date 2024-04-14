using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.EntityFrameworkCore;
using Web_App.Models;
using Web_App.ViewModels;

namespace Web_App.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //foreach (var property in modelBuilder.Model.GetEntityTypes()
            //             .SelectMany(e => e.GetProperties()
            //                 .Where(p => p.ClrType == typeof(string)))) --> Limits all varchar type in database to has 200 max characters
                

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DbContext).Assembly); // Isso vai fazer o mapping de Products, Suppliers & Addresses automáticamente, sem ter que fazer manualmente um por um!

            //foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            //    relationship.DeleteBehavior = DeleteBehavior.ClientSetNull; ---> Esse foreach evita a remoção de arquivos via delete cascade

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<ProductViewModel> SupplierViewModel { get; set; } = default!;
        public DbSet<ProductViewModel> ProductViewModel { get; set; }
        public DbSet<AddressViewModel> AddressViewModel { get; set; }
    }
}
