using Microsoft.EntityFrameworkCore;

namespace _008_ManyToMany
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "DATA SOURCE=403-8\\MSSQLSERVERSTEP; DATABASE=EFStudentCourseInitDB; UID=sa; PWD=1; TrustServerCertificate=True;";
            optionsBuilder.UseSqlServer(connectionString);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Student>().
                HasMany(s => s.Courses)
                .WithMany(c => c.Students);


            // 1. Сідінг курсів
            modelBuilder.Entity<Course>().HasData(
                new Course { Id = 1, Name = "Математичний аналіз" },
                new Course { Id = 2, Name = "Програмування C#" },
                new Course { Id = 3, Name = "Бази даних" }
            );

            // 2. Сідінг студентів
            modelBuilder.Entity<Student>().HasData(
                new Student { Id = 1, Name = "Олексій" },
                new Student { Id = 2, Name = "Марія" }
            );

            // 3. Сідінг зв'язків (таблиця-посередник)
            modelBuilder.Entity("CourseStudent").HasData(
                new { CoursesId = 1, StudentsId = 1 }, // Олексій на Математиці
                new { CoursesId = 2, StudentsId = 1 }, // Олексій на C#
                new { CoursesId = 2, StudentsId = 2 }, // Марія на C#
                new { CoursesId = 3, StudentsId = 2 }  // Марія на Базах даних
            );
        }
    }
}
