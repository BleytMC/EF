using _007_HW2;

using ApplicationDbContext db = new ApplicationDbContext();

Street street1 = new Street() { Name = "Shevchenka" };
Street street2 = new Street() { Name = "Franka" };
Street street3 = new Street() { Name = "Hrushevskoho" };
Street street4 = new Street() { Name = "Bandery" };

House house1 = new House() { Number = 1, Street = street1 };
House house2 = new House() { Number = 2, Street = street1 };
House house3 = new House() { Number = 5, Street = street1 };

House house4 = new House() { Number = 3, Street = street2 };
House house5 = new House() { Number = 7, Street = street2 };
House house6 = new House() { Number = 10, Street = street2 };

House house7 = new House() { Number = 4, Street = street3 };
House house8 = new House() { Number = 8, Street = street3 };

House house9 = new House() { Number = 12, Street = street4 };
House house10 = new House() { Number = 15, Street = street4 };

db.Streets.AddRange(street1, street2, street3, street4);

db.Houses.AddRange(
    house1, house2, house3,
    house4, house5, house6,
    house7, house8,
    house9, house10
);

db.SaveChanges();