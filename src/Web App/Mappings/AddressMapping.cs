﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Web_App.Models;

namespace Web_App.Mappings;

public class AddressMapping : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.HasKey(a => a.Id);

        builder.Property(a => a.Patio)
            .IsRequired()
            .HasColumnType("varchar(100)");

        builder.Property(a => a.Number)
            .IsRequired()
            .HasColumnType("varchar(10)");

        builder.Property(a => a.Complement)
            .IsRequired()
            .HasColumnType("varchar(50)");

        builder.Property(a => a.ZipCode)
            .IsRequired()
            .HasColumnType("varchar(8)");

        builder.Property(a => a.Neighborhood)
            .IsRequired()
            .HasColumnType("varchar(50)");

        builder.Property(a => a.City)
            .IsRequired()
            .HasColumnType("varchar(50)");

        builder.Property(a => a.State)
            .IsRequired()
            .HasColumnType("varchar(30)");

        builder.ToTable("Addresses");
    }
}