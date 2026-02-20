using Microsoft.EntityFrameworkCore;

namespace _001_FirstExample
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "DATA SOURCE=403-8\\MSSQLSERVERSTEP; DATABASE=PeopleDB; UID=sa; PWD=1; TrustServerCertificate=True;";
            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<Person> People { get; set; }
    }
}