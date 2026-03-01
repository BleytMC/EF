using Microsoft.EntityFrameworkCore;

namespace _006_HW1
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<Car> Cars { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "DATA SOURCE=RomanPC; DATABASE=EFCarsDB; UID=sa; PWD=1; TrustServerCertificate=True;";
            optionsBuilder.UseSqlServer(connectionString);

        }
    }
}
