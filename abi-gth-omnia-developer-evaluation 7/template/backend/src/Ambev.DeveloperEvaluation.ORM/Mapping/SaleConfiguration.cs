using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class SaleConfiguration : IEntityTypeConfiguration<Sale>
{
    public void Configure(EntityTypeBuilder<Sale> builder)
    {
        builder.ToTable("Sales");

        builder.HasKey(s => s.Id);
        builder.Property(s => s.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

        builder.Property(s => s.SaleNumber)
            .IsRequired();

        builder.Property(s => s.SaleDate)
            .IsRequired();

        builder.Property(s => s.Customer)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(s => s.TotalAmount)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(s => s.Branch)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(s => s.IsCancelled)
            .IsRequired();

    }
}