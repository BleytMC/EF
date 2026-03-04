using _008_ManyToMany;
using Microsoft.EntityFrameworkCore;

using ApplicationDbContext db = new ApplicationDbContext();

//Student student1 = new Student() { Name = "John" };
//Student student2 = new Student() { Name = "Den" };
//Student student3 = new Student() { Name = "Bob" };

//db.Students.AddRange(student1, student2, student3);

//Course course1 = new Course() { Name = "Programming" };
//Course course2 = new Course() { Name = "Design" };

//db.Courses.AddRange(course1, course2);

//course1.Students.AddRange(student1, student2);
//course2.Students.AddRange(student3, student2);

//db.SaveChanges();


//List<Course> courses = db.Courses.Include(c => c.Students).ToList();

//foreach(Course course in courses)
//{
//    Console.WriteLine(course.Name);
//    foreach(Student student in course.Students)
//    {
//        Console.WriteLine($"\t{student.Name}");
//    }
//}


//Student? student = db.Students.Where(s => s.Id == 2).Include(s => s.Courses).FirstOrDefault();
//Course? course = db.Courses.Where(c => c.Id == 1).FirstOrDefault();

//student?.Courses.Remove(course);

//db.SaveChanges();


//Student student = new Student() { Name = "Ben" };

//db.Students.Add(student);

//db.Courses.Where(c => c.Id == 1).FirstOrDefault().Students.Add(student);

//db.SaveChanges();


//Course? course = db.Courses.Where(c => c.Id == 1).FirstOrDefault();
//Student? student = db.Students.Where(s => s.Id == 3).FirstOrDefault();

//course.Students.Add(student);
//db.SaveChanges();