using Microsoft.EntityFrameworkCore;

namespace _003_OneToMany
{
    class ApplicationDBContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "DATA SOURCE=403-8\\MSSQLSERVERSTEP; DATABASE=EFProductCategoryInitDB; UID=sa; PWD=1; TrustServerCertificate=True;";
            optionsBuilder.UseSqlServer(connectionString);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Category category1 = new Category() { Id = 1, Title = "Tech" };
            Category category2 = new Category() { Id = 2, Title = "Food" };

            Product product1 = new Product() { Id = 1, Name = "TV", Price = 1000, CategoryId = category1.Id };
            Product product2 = new Product() { Id = 2, Name = "Tablet", Price = 3000, CategoryId = category1.Id };
            Product product3 = new Product() { Id = 3, Name = "Burger", Price = 3434, CategoryId = category2.Id };

            modelBuilder.Entity<Product>().HasData(product1, product2, product3);
            modelBuilder.Entity<Category>().HasData(category1, category2);
        }
    }
}
