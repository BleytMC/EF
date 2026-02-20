using _002_AppWithMigarations;

using ApplicationDBContext context = new ApplicationDBContext();

// Create

//Person person = new Person
//{
//    Name = "Emma",
//    LastName = "Brown",
//    BirthDate = new DateTime(1995, 2, 25)
//};

//context.People.Add(person);
//context.SaveChanges();


// Update

//Person? person = context.People.Where(p => p.Id == 1).FirstOrDefault();

//person.Name = "Tony";

//context.SaveChanges();


// Delete

//Person? person = context.People.Where(p => p.Id == 1).FirstOrDefault();

//context.People.Remove(person);

//context.SaveChanges();


// Read

//List<Person> people = context.People.ToList();
//foreach(Person person in people)
//{
//    Console.WriteLine($"Id: {person.Id}\tName: {person.Name}\tLastName: {person.LastName}   \tBirthdate: {person.BirthDate}");
//}