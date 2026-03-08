using Microsoft.EntityFrameworkCore;

namespace _007_HW2
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<House> Houses { get; set; }
        public DbSet<Street> Streets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "DATA SOURCE=RomanPC; DATABASE=EFHouseStreetDB; UID=sa; PWD=1; TrustServerCertificate=True;";
            optionsBuilder.UseSqlServer(connectionString);

        }
    }
}
