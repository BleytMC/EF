using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace _010_FluentAPIOneToMany
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {

            builder.ToTable("Goods");
            builder.HasKey(p => p.Id);
            builder.Ignore(p => p.Info);

            builder.Property(p => p.Name).HasColumnName("Title");
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.Name).HasMaxLength(20);
            builder.Property(p => p.Name).HasColumnType("NVARCHAR");
            builder.Property(p => p.Price).HasDefaultValue(0);

            builder.ToTable(
                t => t.HasCheckConstraint("Price", "Price >= 0 AND Price < 10000")
                    .HasName("Check product price")
                );
        }
    }
}
