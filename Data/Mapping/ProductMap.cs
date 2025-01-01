using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SorveSoftApi.Models;

namespace SorveSoftApi.Data.Mapping
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("TB_Products");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(200).IsRequired();
            builder.Property(p => p.Category).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Price).HasColumnType("decimal(10,2)").IsRequired();
            builder.Property(p => p.Quantity).IsRequired();
            builder.Property(p => p.ImageUrl).HasMaxLength(200).IsRequired();
        }
    }
}
