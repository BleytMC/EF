using _016_Exam.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _016_Exam.Configurations
{
    public class ShelvedDiscsConfiguration : IEntityTypeConfiguration<ShelvedDiscs>
    {
        public void Configure(EntityTypeBuilder<ShelvedDiscs> builder)
        {
            builder.ToTable(t => t.HasCheckConstraint("Amount", "Amount >= 0"));
        }
    }
}
