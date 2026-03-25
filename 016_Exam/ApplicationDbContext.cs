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
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<ShelvedDiscs> ShelvedDiscs { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Purchase> Purchases { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "DATA SOURCE=403-8\\MSSQLSERVERSTEP; DATABASE=EFExamDB; UID=sa; PWD=1; TrustServerCertificate=True;";
            //string connectionString = "DATA SOURCE=RomanPC; DATABASE=EFExamDB; UID=sa; PWD=1; TrustServerCertificate=True;";
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer(connectionString);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DiscConfiguration());
            modelBuilder.ApplyConfiguration(new SaleConfiguration());
            modelBuilder.ApplyConfiguration(new ShelvedDiscsConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new PurchaseConfiguration());

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Login = "a", Password = "1", PermissionLevel = 1}
            );

            modelBuilder.Entity<Ganre>().HasData(
                new Ganre { Id = 1, Name = "Rock" },
                new Ganre { Id = 2, Name = "Pop" },
                new Ganre { Id = 3, Name = "Jazz" },
                new Ganre { Id = 4, Name = "Hip-Hop" },
                new Ganre { Id = 5, Name = "Classical" }
            );

            modelBuilder.Entity<Author>().HasData(
                new Author { Id = 1, Name = "John", Surname = "Smith" },
                new Author { Id = 2, Name = "Emma", Surname = "Johnson" },
                new Author { Id = 3, Name = "Michael", Surname = "Brown" },
                new Author { Id = 4, Name = "Olivia", Surname = "Davis" },
                new Author { Id = 5, Name = "William", Surname = "Miller" },
                new Author { Id = 6, Name = "Sophia", Surname = "Wilson" }
            );

            modelBuilder.Entity<Publisher>().HasData(
                new Publisher { Id = 1, Name = "Universal Music" },
                new Publisher { Id = 2, Name = "Sony Music" },
                new Publisher { Id = 3, Name = "Warner Music" }
            );

            modelBuilder.Entity<Disc>().HasData(
                new Disc { Id = 1, Name = "Rock Legends", Cost = 5.2, Price = 15.9, SongsCount = 12, Amount = 50, ReleaseDate = new DateOnly(2010, 5, 12), GanreId = 1, AuthorId = 1, PublisherId = 1 },
                new Disc { Id = 2, Name = "Pop Hits", Cost = 4.0, Price = 12.5, SongsCount = 10, Amount = 80, ReleaseDate = new DateOnly(2015, 3, 8), GanreId = 2, AuthorId = 2, PublisherId = 2 },
                new Disc { Id = 3, Name = "Jazz Night", Cost = 6.5, Price = 18.0, SongsCount = 8, Amount = 40, ReleaseDate = new DateOnly(2008, 11, 21), GanreId = 3, AuthorId = 3, PublisherId = 3 },
                new Disc { Id = 4, Name = "Hip-Hop Beats", Cost = 3.8, Price = 11.0, SongsCount = 14, Amount = 70, ReleaseDate = new DateOnly(2020, 7, 15), GanreId = 4, AuthorId = 4, PublisherId = 2 },
                new Disc { Id = 5, Name = "Classic Collection", Cost = 7.5, Price = 20.0, SongsCount = 20, Amount = 30, ReleaseDate = new DateOnly(2000, 1, 1), GanreId = 5, AuthorId = 5, PublisherId = 3 },

                new Disc { Id = 6, Name = "Rock Arena", Cost = 5.0, Price = 14.0, SongsCount = 11, Amount = 55, ReleaseDate = new DateOnly(2012, 6, 18), GanreId = 1, AuthorId = 6, PublisherId = 1 },
                new Disc { Id = 7, Name = "Pop Dreams", Cost = 4.2, Price = 13.0, SongsCount = 13, Amount = 75, ReleaseDate = new DateOnly(2016, 4, 10), GanreId = 2, AuthorId = 1, PublisherId = 2 },
                new Disc { Id = 8, Name = "Smooth Jazz", Cost = 6.0, Price = 17.5, SongsCount = 7, Amount = 35, ReleaseDate = new DateOnly(2009, 2, 25), GanreId = 3, AuthorId = 2, PublisherId = 3 },
                new Disc { Id = 9, Name = "Street Beats", Cost = 3.5, Price = 10.5, SongsCount = 15, Amount = 90, ReleaseDate = new DateOnly(2021, 8, 5), GanreId = 4, AuthorId = 3, PublisherId = 1 },
                new Disc { Id = 10, Name = "Symphony Best", Cost = 8.0, Price = 22.0, SongsCount = 25, Amount = 20, ReleaseDate = new DateOnly(1995, 12, 12), GanreId = 5, AuthorId = 4, PublisherId = 2 },

                new Disc { Id = 11, Name = "Rock Energy", Cost = 5.1, Price = 15.0, SongsCount = 12, Amount = 45, ReleaseDate = new DateOnly(2011, 3, 3), GanreId = 1, AuthorId = 5, PublisherId = 3 },
                new Disc { Id = 12, Name = "Pop Star", Cost = 4.4, Price = 13.9, SongsCount = 11, Amount = 85, ReleaseDate = new DateOnly(2017, 9, 9), GanreId = 2, AuthorId = 6, PublisherId = 1 },
                new Disc { Id = 13, Name = "Jazz Classics", Cost = 6.8, Price = 19.0, SongsCount = 9, Amount = 25, ReleaseDate = new DateOnly(2007, 6, 14), GanreId = 3, AuthorId = 1, PublisherId = 2 },
                new Disc { Id = 14, Name = "Rap Kings", Cost = 3.9, Price = 12.0, SongsCount = 16, Amount = 95, ReleaseDate = new DateOnly(2022, 2, 2), GanreId = 4, AuthorId = 2, PublisherId = 3 },
                new Disc { Id = 15, Name = "Orchestra Gold", Cost = 7.8, Price = 21.5, SongsCount = 18, Amount = 15, ReleaseDate = new DateOnly(1998, 10, 30), GanreId = 5, AuthorId = 3, PublisherId = 1 }
            );
        }
    }
}
