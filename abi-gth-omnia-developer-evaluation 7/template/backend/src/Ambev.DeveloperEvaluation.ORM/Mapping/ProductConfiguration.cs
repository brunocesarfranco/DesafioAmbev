using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");

        // Chave primária
        builder.HasKey(si => si.Id);

        builder.Property(si => si.Title)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(si => si.Category)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(si => si.Quantity)
            .IsRequired();

        builder.Property(si => si.UnitPrice)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(si => si.Discount)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        //builder.Property(si => si.TotalItemAmount)
        // .HasColumnType("decimal(18,2)");
        //.HasComputedColumnSql("[UnitPrice] * [Quantity] - [Discount]", stored: true);
    }
}
