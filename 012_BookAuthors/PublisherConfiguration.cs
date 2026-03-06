using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _012_BookAuthors
{
    public class PublisherConfiguration : IEntityTypeConfiguration<Publisher>
    {

        public void Configure(EntityTypeBuilder<Publisher> builder)
        {
            builder.HasKey(p => p.Id);
        }
    }
}
