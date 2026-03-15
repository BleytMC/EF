using Microsoft.EntityFrameworkCore;

namespace _009_Films
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<Studio> Studios { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<Actor> Actors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "DATA SOURCE=RomanPC; DATABASE=EFFilmsDB; UID=sa; PWD=1; TrustServerCertificate=True;";
            optionsBuilder.UseSqlServer(connectionString);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Studio>().HasData(
                new Studio { Id = 1, Name = "Warner Bros" },
                new Studio { Id = 2, Name = "Universal Pictures" },
                new Studio { Id = 3, Name = "Paramount Pictures" }
            );

            modelBuilder.Entity<Film>().HasData(
                new Film { Id = 1, Title = "Inception", StudioId = 1 },
                new Film { Id = 2, Title = "Jurassic Park", StudioId = 2 },
                new Film { Id = 3, Title = "Top Gun", StudioId = 3 }
            );

            modelBuilder.Entity<Actor>().HasData(
                new Actor { Id = 1, Name = "Leonardo", Surname = "DiCaprio" },
                new Actor { Id = 2, Name = "Sam", Surname = "Neill" },
                new Actor { Id = 3, Name = "Tom", Surname = "Cruise" },
                new Actor { Id = 4, Name = "Joseph", Surname = "Gordon-Levitt" }
            );

            modelBuilder.Entity("ActorFilm").HasData(
                // Inception
                new { ActorsId = 1, FilmsId = 1 },
                new { ActorsId = 4, FilmsId = 1 },

                // Jurassic Park
                new { ActorsId = 2, FilmsId = 2 },

                // Top Gun
                new { ActorsId = 3, FilmsId = 3 }
            );
        }
    }
}
