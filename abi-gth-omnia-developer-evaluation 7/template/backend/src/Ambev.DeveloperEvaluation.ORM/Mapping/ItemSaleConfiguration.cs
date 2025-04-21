using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class ItemSaleConfiguration : IEntityTypeConfiguration<ItemSale>
{
    public void Configure(EntityTypeBuilder<ItemSale> builder)
    {
        builder.ToTable("ItemSales");

        // Chave primária
        builder.HasKey(isl => isl.Id);

        // Relacionamento com Sale
        builder.HasOne(isl => isl.Sale)
            .WithMany(s => s.Items)
            .HasForeignKey(isl => isl.SaleId)
            .OnDelete(DeleteBehavior.Cascade);

        // Relacionamento com Product
        builder.HasOne(isl => isl.Product)
            .WithMany()
            .HasForeignKey(isl => isl.ProductId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(isl => isl.Quantity)
            .IsRequired();

        builder.Property(isl => isl.UnitPrice)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(isl => isl.Discount)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(isl => isl.TotalAmount)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(isl => isl.IsCancelled)
            .IsRequired();
    }
}
