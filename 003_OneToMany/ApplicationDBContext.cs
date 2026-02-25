using Microsoft.EntityFrameworkCore;

namespace _003_OneToMany
{
    class ApplicationDBContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "DATA SOURCE=403-8\\MSSQLSERVERSTEP; DATABASE=EFProductCategoryDB; UID=sa; PWD=1; TrustServerCertificate=True;";
            optionsBuilder.UseSqlServer(connectionString);

        }
    }
}
