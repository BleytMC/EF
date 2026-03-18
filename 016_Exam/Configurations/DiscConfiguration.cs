using _016_Exam.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _016_Exam.Configurations
{
    public class DiscConfiguration : IEntityTypeConfiguration<Disc>
    {
        public void Configure(EntityTypeBuilder<Disc> builder)
        {
            builder.ToTable(t => t.HasCheckConstraint("Amount", "Amount >= 0"));
            builder.ToTable(t => t.HasCheckConstraint("Sold", "Sold >= 0"));
            builder.ToTable(t => t.HasCheckConstraint("Shelved", "Shelved >= 0"));

            builder.ToTable(t => t.HasCheckConstraint("Cost", "Cost >= 0"));
            builder.ToTable(t => t.HasCheckConstraint("Price", "Price > Cost"));
        }
    }
}
