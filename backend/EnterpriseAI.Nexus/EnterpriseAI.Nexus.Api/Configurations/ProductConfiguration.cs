using EnterpriseAI.Nexus.Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EnterpriseAI.Nexus.Api.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");

        builder.HasKey(product => product.ProductId);

        builder.HasIndex(product => product.ProductCode)
            .IsUnique();

        builder.Property(product => product.ProductCode)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(product => product.ProductName)
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(product => product.Description)
            .HasMaxLength(500);

        builder.Property(product => product.Category)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(product => product.UnitOfMeasure)
            .HasMaxLength(30)
            .IsRequired();

        builder.Property(product => product.StandardUnitPrice)
            .HasPrecision(18, 2);
    }
}