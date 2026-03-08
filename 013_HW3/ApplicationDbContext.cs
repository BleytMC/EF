using Microsoft.EntityFrameworkCore;

namespace _013_HW3
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "DATA SOURCE=RomanPC; DATABASE=EFProductCategoryLazyDB; UID=sa; PWD=1; TrustServerCertificate=True;";
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer(connectionString);

        }
    }
}
