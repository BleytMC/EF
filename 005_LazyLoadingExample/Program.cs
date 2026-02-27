using _005_LazyLoadingExample;

using ApplicationDbContext db = new ApplicationDbContext();

//Company company1 = new Company() { Name = "Google" };
//Company company2 = new Company() { Name = "Microsoft" };

//db.Companies.Add(company1);
//db.Companies.Add(company2);

//db.SaveChanges();

//User user1 = new User() { Name = "John Smith", CompanyId = company1.Id };
//User user2 = new User() { Name = "Den Brown", CompanyId = company1.Id };
//User user3 = new User() { Name = "John Wcik", CompanyId = company2.Id };
//User user4 = new User() { Name = "Lary Smith", CompanyId = company2.Id };
//User user5 = new User() { Name = "Bob Ten", CompanyId = company2.Id };

//db.Users.AddRange(user1, user2, user3, user4, user5);
//db.SaveChanges();


List<User> users = db.Users.ToList();

foreach(User user  in users)
{
    Console.WriteLine($"Name: {user.Name, -15}Company: {user.Company.Name, -10}");
}