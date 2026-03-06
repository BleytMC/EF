using Microsoft.EntityFrameworkCore;

namespace _011_LINQToSQL
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Company> Companies { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(@"DATA SOURCE=403-8\MSSQLSERVERSTEP; DATABASE=EFUserCompaniesSQL; UID=sa; PWD=1; TrustServerCertificate=True;");
        }
    }
}
