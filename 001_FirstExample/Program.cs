using _001_FirstExample;

using ApplicationDBContext context = new ApplicationDBContext();

Person person = new Person
{
    Name = "Den",
    LastName = "Smith",
    BirthDate = new DateTime(2001, 3, 15)
};

context.People.Add(person);
context.SaveChanges();