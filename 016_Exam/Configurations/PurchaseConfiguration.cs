using _016_Exam.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _016_Exam.Configurations
{
    public class PurchaseConfiguration : IEntityTypeConfiguration<Purchase>
    {
        public void Configure(EntityTypeBuilder<Purchase> builder)
        {
            builder.ToTable(t => t.HasCheckConstraint("Amount", "Amount > 0"));
            builder.ToTable(t => t.HasCheckConstraint("PriceForOne", "PriceForOne > 0"));
            builder.ToTable(t => t.HasCheckConstraint("FinalPrice", "FinalPrice >= PriceForOne"));
        }
    }
}
