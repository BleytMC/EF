using _006_HW1;

using ApplicationDbContext db = new ApplicationDbContext();

//List<Car> cars = new List<Car>
//{
//    new Car { Name = "Nissan", Price = 12000.0f, Color = "Black",  ReleaseDate = new (2010, 1, 20) },
//    new Car { Name = "Toyota", Price = 15000.0f, Color = "White",  ReleaseDate = new (2015, 5, 14) },
//    new Car { Name = "BMW",    Price = 22000.0f, Color = "Blue",   ReleaseDate = new (2018, 3, 10) },
//    new Car { Name = "Audi",   Price = 25000.0f, Color = "Gray",   ReleaseDate = new (2020, 7, 5) },
//    new Car { Name = "Ford",   Price = 10000.0f, Color = "Red",    ReleaseDate = new (2008, 11, 2) }
//};

//db.AddRange(cars);
//db.SaveChanges();


int choice = 0;

List<Car> cars = db.Cars.ToList();

do
{
    Console.Clear();
    foreach (Car car in cars) Console.WriteLine(car);

    Console.WriteLine(new string('-', 77));
    Console.WriteLine("1 - Add new car");
    Console.WriteLine("2 - Remove car");
    Console.WriteLine("3 - Edit car");
    Console.WriteLine();

    choice = Convert.ToInt32(Console.ReadLine());

    int id;
    string name, color;
    float price;
    DateTime dt;
    DateOnly releaseDate;

    switch (choice)
    {
        case 1:
            Console.Write("Enter name: ");
            name = Console.ReadLine();
            Console.Write("Enter price: ");
            price = Convert.ToSingle(Console.ReadLine());
            Console.Write("Enter color: ");
            color = Console.ReadLine();
            Console.Write("Enter release date: ");
            dt = Convert.ToDateTime(Console.ReadLine());
            releaseDate = new DateOnly(dt.Year, dt.Month, dt.Day);

            Car car = new Car() { Name = name, Color = color, Price = price, ReleaseDate = releaseDate };
            db.Cars.Add(car);
            db.SaveChanges();
            cars = db.Cars.ToList();
            break;

        case 2:
            Console.Write("Enter Id: ");
            id = Convert.ToInt32(Console.ReadLine());

            Car? carToRemove = db.Cars.Where(c => c.Id == id).FirstOrDefault();
            if(carToRemove == null) Console.WriteLine("Car with this id does not exist");
            else
            {
                db.Cars.Remove(carToRemove);
                db.SaveChanges();
                cars = db.Cars.ToList();
                Console.WriteLine("Car has been deleted");
            }
            Console.ReadLine();
            break;

        case 3:
            Console.WriteLine("Enter new information (leave empty or 0 for price to save old)");
            Console.Write("Enter car Id: ");
            id = Convert.ToInt32(Console.ReadLine());

            Car? carToUpdate = db.Cars.Where(c => c.Id == id).FirstOrDefault();
            if(carToUpdate == null) Console.WriteLine("Car with this id does not exist");
            else
            {
                Console.Write("Enter name: ");
                name = Console.ReadLine();
                if(name == "") name = carToUpdate.Name;

                Console.Write("Enter price: ");
                price = Convert.ToSingle(Console.ReadLine());
                if(price == 0) price = carToUpdate.Price;

                Console.Write("Enter color: ");
                color = Console.ReadLine();
                if(color == "") color = carToUpdate.Color;

                Console.Write("Enter release date: ");
                string buf = Console.ReadLine();
                if(buf == "") releaseDate = carToUpdate.ReleaseDate;
                else
                {
                    dt = Convert.ToDateTime(buf);
                    releaseDate = new DateOnly(dt.Year, dt.Month, dt.Day);
                }

                carToUpdate.Name = name;
                carToUpdate.Price = price;
                carToUpdate.Color = color;
                carToUpdate.ReleaseDate = releaseDate;

                db.SaveChanges();
                cars = db.Cars.ToList();

                Console.WriteLine("Car has been changed");
            }
            Console.ReadLine();
            break;
    }
} while (choice != 0);