using Microsoft.EntityFrameworkCore;

namespace _004_NavigationProperties
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "DATA SOURCE=403-8\\MSSQLSERVERSTEP; DATABASE=EFUserCompanyDB; UID=sa; PWD=1; TrustServerCertificate=True;";
            optionsBuilder.UseSqlServer(connectionString);

        }
    }
}
