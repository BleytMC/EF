using Microsoft.EntityFrameworkCore;

namespace _012_BookAuthors
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; } = null!;
        public DbSet<Author> Authors { get; set; } = null!;
        public DbSet<Publisher> Publishers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(@"DATA SOURCE=403-8\MSSQLSERVERSTEP; DATABASE=EFBookAuthorsDB; UID=sa; PWD=1; TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookConfiguration());
            modelBuilder.ApplyConfiguration(new AuthorConfiguration());
            modelBuilder.ApplyConfiguration(new PublisherConfiguration());

            modelBuilder.Entity<Publisher>().HasData(
                new Publisher { Id = 1, Name = "Penguin Books" },
                new Publisher { Id = 2, Name = "HarperCollins" },
                new Publisher { Id = 3, Name = "Simon & Schuster" },
                new Publisher { Id = 4, Name = "Oxford Press" },
                new Publisher { Id = 5, Name = "Cambridge Press" },
                new Publisher { Id = 6, Name = "Springer" },
                new Publisher { Id = 7, Name = "Packt Publishing" },
                new Publisher { Id = 8, Name = "Manning Publications" },
                new Publisher { Id = 9, Name = "O’Reilly Media" },
                new Publisher { Id = 10, Name = "No Starch Press" }
            );

            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Name = "C# Fundamentals", Pages = 350, Price = 35.5f, PublisherId = 9 },
                new Book { Id = 2, Name = ".NET Deep Dive", Pages = 420, Price = 40.0f, PublisherId = 9 },
                new Book { Id = 3, Name = "Entity Framework Guide", Pages = 300, Price = 32.2f, PublisherId = 8 },
                new Book { Id = 4, Name = "ASP.NET Core Web", Pages = 500, Price = 45.0f, PublisherId = 8 },
                new Book { Id = 5, Name = "LINQ in Action", Pages = 280, Price = 28.9f, PublisherId = 7 },
                new Book { Id = 6, Name = "Algorithms Basics", Pages = 610, Price = 55.5f, PublisherId = 6 },
                new Book { Id = 7, Name = "Data Structures", Pages = 540, Price = 50.0f, PublisherId = 6 },
                new Book { Id = 8, Name = "Clean Code Guide", Pages = 450, Price = 42.3f, PublisherId = 10 },
                new Book { Id = 9, Name = "Design Patterns", Pages = 395, Price = 39.9f, PublisherId = 10 },
                new Book { Id = 10, Name = "Microservices Architecture", Pages = 370, Price = 37.5f, PublisherId = 7 },
                new Book { Id = 11, Name = "Docker for Developers", Pages = 260, Price = 29.5f, PublisherId = 7 },
                new Book { Id = 12, Name = "Kubernetes Essentials", Pages = 330, Price = 34.0f, PublisherId = 7 },
                new Book { Id = 13, Name = "AI Basics", Pages = 410, Price = 44.5f, PublisherId = 5 },
                new Book { Id = 14, Name = "Machine Learning Intro", Pages = 390, Price = 41.0f, PublisherId = 5 },
                new Book { Id = 15, Name = "Deep Learning Guide", Pages = 520, Price = 52.0f, PublisherId = 5 },
                new Book { Id = 16, Name = "Python for Data Science", Pages = 360, Price = 36.0f, PublisherId = 4 },
                new Book { Id = 17, Name = "Statistics Essentials", Pages = 300, Price = 31.0f, PublisherId = 4 },
                new Book { Id = 18, Name = "Game Development Basics", Pages = 480, Price = 43.7f, PublisherId = 3 },
                new Book { Id = 19, Name = "Computer Graphics", Pages = 510, Price = 49.5f, PublisherId = 2 },
                new Book { Id = 20, Name = "Operating Systems", Pages = 620, Price = 58.9f, PublisherId = 1 }
            );

            modelBuilder.Entity<Author>().HasData(
                new Author { Id = 1, FirstName = "John", LastName = "Smith" },
                new Author { Id = 2, FirstName = "Michael", LastName = "Johnson" },
                new Author { Id = 3, FirstName = "David", LastName = "Brown" },
                new Author { Id = 4, FirstName = "James", LastName = "Williams" },
                new Author { Id = 5, FirstName = "Robert", LastName = "Jones" },
                new Author { Id = 6, FirstName = "William", LastName = "Garcia" },
                new Author { Id = 7, FirstName = "Richard", LastName = "Miller" },
                new Author { Id = 8, FirstName = "Joseph", LastName = "Davis" },
                new Author { Id = 9, FirstName = "Thomas", LastName = "Rodriguez" },
                new Author { Id = 10, FirstName = "Charles", LastName = "Martinez" },
                new Author { Id = 11, FirstName = "Daniel", LastName = "Hernandez" },
                new Author { Id = 12, FirstName = "Matthew", LastName = "Lopez" },
                new Author { Id = 13, FirstName = "Anthony", LastName = "Gonzalez" },
                new Author { Id = 14, FirstName = "Mark", LastName = "Wilson" },
                new Author { Id = 15, FirstName = "Donald", LastName = "Anderson" }
            );

            modelBuilder.Entity("BookAuthors").HasData(
                new { BooksId = 1, AuthorsId = 1 },
                new { BooksId = 1, AuthorsId = 2 },
                new { BooksId = 2, AuthorsId = 2 },
                new { BooksId = 2, AuthorsId = 3 },
                new { BooksId = 3, AuthorsId = 3 },
                new { BooksId = 3, AuthorsId = 4 },
                new { BooksId = 4, AuthorsId = 4 },
                new { BooksId = 5, AuthorsId = 5 },
                new { BooksId = 6, AuthorsId = 6 },
                new { BooksId = 7, AuthorsId = 6 },
                new { BooksId = 7, AuthorsId = 7 },
                new { BooksId = 8, AuthorsId = 8 },
                new { BooksId = 9, AuthorsId = 9 },
                new { BooksId = 10, AuthorsId = 10 },
                new { BooksId = 11, AuthorsId = 11 },
                new { BooksId = 12, AuthorsId = 12 },
                new { BooksId = 13, AuthorsId = 13 },
                new { BooksId = 14, AuthorsId = 13 },
                new { BooksId = 14, AuthorsId = 14 },
                new { BooksId = 15, AuthorsId = 14 },
                new { BooksId = 16, AuthorsId = 15 },
                new { BooksId = 17, AuthorsId = 1 },
                new { BooksId = 18, AuthorsId = 5 },
                new { BooksId = 19, AuthorsId = 7 },
                new { BooksId = 20, AuthorsId = 9 }
            );
        }
    }
}
