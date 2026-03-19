using _016_Exam.Configurations;
using _016_Exam.Models;
using Microsoft.EntityFrameworkCore;

namespace _016_Exam
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<Disc> Discs { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Ganre> Ganres { get; set; }
        public DbSet<Publisher> Publisher { get; set; }
        public DbSet<Sale> Sale { get; set; }
        public DbSet<ShelvedDiscs> ShelvedDiscs { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Purchase> Purchases { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //string connectionString = "DATA SOURCE=403-8\\MSSQLSERVERSTEP; DATABASE=EFExamDB; UID=sa; PWD=1; TrustServerCertificate=True;";
            string connectionString = "DATA SOURCE=RomanPC; DATABASE=EFExamDB; UID=sa; PWD=1; TrustServerCertificate=True;";
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer(connectionString);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DiscConfiguration());
            modelBuilder.ApplyConfiguration(new SaleConfiguration());
            modelBuilder.ApplyConfiguration(new ShelvedDiscsConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new PurchaseConfiguration());
        }
    }
}
