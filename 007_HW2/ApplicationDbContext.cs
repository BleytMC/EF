using Microsoft.EntityFrameworkCore;

namespace _007_HW2
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "DATA SOURCE=RomanPC; DATABASE=EFProductsCategoriesDB; UID=sa; PWD=1; TrustServerCertificate=True;";
            optionsBuilder.UseSqlServer(connectionString);

        }
    }
}
