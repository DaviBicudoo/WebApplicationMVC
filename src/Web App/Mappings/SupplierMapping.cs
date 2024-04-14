using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Web_App.Models;

namespace Web_App.Mappings;

public class SupplierMapping : IEntityTypeConfiguration<Supplier>
{
    public void Configure(EntityTypeBuilder<Supplier> builder)
    {
        builder.HasKey(s => s.Id);

        builder.Property(s => s.Name)
            .IsRequired()
            .HasColumnType("varchar(100)");

        builder.Property(s => s.Document)
            .IsRequired()
            .HasColumnType("varchar(14)");

        // Relation 1 x 1 => Supplier x Address
        builder.HasOne(s => s.Address).WithOne(a => a.Supplier);

        // Relation 1 x N => Supplier x Product
        builder.HasMany(s => s.Products).WithOne(p => p.Supplier);

        builder.ToTable("Suppliers");
    }
}