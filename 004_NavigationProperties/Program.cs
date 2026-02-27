using _004_NavigationProperties;
using Microsoft.EntityFrameworkCore;

using ApplicationDbContext db = new ApplicationDbContext();

//Company company1 = new Company() { Name = "Google" };
//Company company2 = new Company() { Name = "Microsoft" };

//db.AddRange(company1, company2);
//db.SaveChanges();

//User user1 = new User() { Name = "John Stimth", CompanyId = company1.Id };
//User user2 = new User() { Name = "Den Brown", CompanyId = company1.Id };
//User user3 = new User() { Name = "John Wcik", CompanyId = company2.Id };
//User user4 = new User() { Name = "Lary Smith", CompanyId = company2.Id };
//User user5 = new User() { Name = "Bob Ten", CompanyId = company2.Id };

//db.Users.AddRange(user1, user2, user3, user4, user5);
//db.SaveChanges();


//Company company1 = new Company() { Name = "IBM" };
//Company company2 = new Company() { Name = "Apple" };

//User user1 = new User() { Name = "Tony Stark", company = company1 };
//User user2 = new User() { Name = "A B", company = company2 };
//User user3 = new User() { Name = "Jim Kerry", company = company2 };

//db.Companies.AddRange(company1, company2);
//db.Users.AddRange(user1, user2, user3);

//db.SaveChanges();


//User user1 = new User() { Name = "Bob Big" };
//User user2 = new User() { Name = "Ivan B" };
//User user3 = new User() { Name = "Danylo Lisnichuk" };

//Company company1 = new Company() { Name = "HP", Users = { user1, user2 } };
//Company company2 = new Company() { Name = "Samsung", Users = { user3 } };

//db.Companies.AddRange(company1, company2);
//db.Users.AddRange(user1, user2, user3);

//db.SaveChanges();


// Підтягуванняданих за допомогою навігаційних властивостей

// Eager Loading (жадібне завантаження)
// Explicit Loading (явне завантаження)
// Lazy Loading (ліниве завантаження)


// Eager Loading (жадібне завантаження)


//List<User> users = db.Users.Include(u => u.company).ToList();

//foreach (User user in users)
//{
//    Console.WriteLine($"Id: {user.Id, -4} Name: {user.Name, -20} CompanyId: {user.CompanyId, -4} Company: {user.company?.Name, -15}");
//}


//List<Company> companies = db.Companies.Include(c => c.Users).ToList();

//foreach (Company company in companies)
//{
//    Console.WriteLine($"Id: {company.Id,-4}Name: {company.Name,-10}Users:");
//    foreach (User user in company.Users)
//        Console.WriteLine($"\tId: {user.Id,-4}Name: {user.Name,-20}");
//}


// Explicit Loading (явне завантаження)


//Company? company = db.Companies.FirstOrDefault();

//if(company != null)
//{
//    //db.Users.Where(u => u.CompanyId == company.Id).Load();
//    db.Entry(company).Collection(c => c.Users).Load();

//    Console.WriteLine(company.Name);
//    foreach(User user in company.Users)
//    {
//        Console.WriteLine(user.Name);
//    }
//}


User? user = db.Users.FirstOrDefault();

if(user != null)
{
    db.Entry(user).Reference(u => u.company).Load();

    Console.WriteLine($"Name: {user.Name, -15}Company: {user.company?.Name, -10}");
}