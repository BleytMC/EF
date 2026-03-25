using _016_Exam;
using _016_Exam.Models;
using Microsoft.EntityFrameworkCore;

using ApplicationDbContext db = new ApplicationDbContext();

User? currentUser = null;

bool running = true;
int option;

do
{
    Console.Clear();
    if(currentUser == null) Console.WriteLine("No user",-25);
    else Console.WriteLine(currentUser.Login,-25);
    Console.WriteLine(new string('-', 50));
    Console.WriteLine("1 - View all discs");
    Console.WriteLine("2 - View your cart");
    Console.WriteLine("3 - View your purchase history");
    if(currentUser == null) Console.WriteLine("4 - Log in");
    Console.WriteLine(new string('-', 50));
    Console.Write("Choose option: ");
    option = Convert.ToInt32(Console.ReadLine());
    switch (option)
    {
        case 0:
            running = false;
            break;
        case 1:
            Console.Clear();
            Console.WriteLine($"{"Id",-5}{"Name",-20}{"Ganre",-15}{"Author",-20}{"Publisher",-20}{"Release Date",-15}{"Songs",-8}{"Price",-8}{"Amount",-8}");
            Console.WriteLine(new string('-', 117));
            if(db.Discs.Count() == 0)
            {
                Console.WriteLine("No discs available");
            }
            else
            {
                Disc[] discs = db.Discs.Where(d => d.Amount > 0).ToArray();
                for(int i = 0; i < discs.Length; i++)
                {
                    Console.Write($"{i,-5}{discs[i].Name,-20}{discs[i].Ganre.Name,-15}{discs[i].Author.Name,-10}{discs[i].Author.Surname,-10}{discs[i].Publisher.Name,-20}{discs[i].ReleaseDate,-15}{discs[i].SongsCount,-8}");
                    if (discs[i].Sales.Count() == 0) Console.Write($"{discs[i].Price.ToString("F2"),-8}");
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write($"{(discs[i].Price / 100 * (100 - discs[i].Sales.Max(s => s.Discount))).ToString("F2"),-8}");
                        Console.ResetColor();
                    }
                    Console.WriteLine($"{discs[i].Amount,-8}");
                }
                Console.WriteLine(new string('-', 117));
                Console.WriteLine("1 - Add to cart");
                if(currentUser != null && currentUser.PermissionLevel > 0)
                {
                    Console.WriteLine("2 - Add disc");
                    Console.WriteLine("3 - Remove disc");
                    Console.WriteLine("4 - Edit sales");
                }
                Console.WriteLine(new string('-', 117));
                Console.Write("Choose option: ");
                option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        if (currentUser == null)
                        {
                            Console.Write("\nTo add discs your cart you have to log in");
                            Console.ReadLine();
                            break;
                        }
                        Console.Write("\nEnter disc id: ");
                        int discToShelveId = Convert.ToInt32(Console.ReadLine());
                        if(discToShelveId < 0 || discToShelveId >= discs.Length)
                        {
                            Console.WriteLine("\nId is out of range");
                            Console.ReadLine();
                            break;
                        }
                        else
                        {
                            Console.Write("Enter amount: ");
                            int discToShelveAmount = Convert.ToInt32(Console.ReadLine());
                            if(discToShelveAmount < 0 || discToShelveAmount > discs[discToShelveId].Amount)
                            {
                                Console.WriteLine("\nAmount is not avaliable");
                                Console.ReadLine();
                                break;
                            }
                            else
                            {                                
                                discs[discToShelveId].Amount -= discToShelveAmount;
                                discs[discToShelveId].Shelved += discToShelveAmount;
                                ShelvedDiscs discsToShelve = new() { User = currentUser, Amount = discToShelveAmount, Disc = discs[discToShelveId] };
                                db.ShelvedDiscs.Add(discsToShelve);

                                db.SaveChanges();

                                Console.WriteLine("\nDisc was added to your car successfully");
                                Console.ReadLine();
                            }
                        }                        
                        break;
                    case 2:
                        if(currentUser == null || currentUser.PermissionLevel == 0)
                        {
                            Console.WriteLine("\nYou don't have permission");
                            Console.ReadLine();
                        }
                        else
                        {
                            Ganre newDiscGanre;
                            Author newDiscAuthor;
                            Publisher newDiscPublisher;

                            Console.Clear();
                            Console.Write("Enter disc name: ");
                            string newDiscName = Console.ReadLine();

                            Console.Clear();
                            Console.WriteLine(new string('-', 30));
                            Console.WriteLine("0 - Add new ganre");
                            for(int i = 0; i < db.Ganres.Count(); i++)
                            {
                                Console.WriteLine($"{i + 1,-4}{db.Ganres.ToArray()[i].Name}");
                            }
                            Console.WriteLine(new string('-', 30));
                            Console.Write("Choose ganre: ");
                            int newDiscGanreId = Convert.ToInt32(Console.ReadLine());
                            if(newDiscGanreId < 0 || newDiscGanreId > db.Ganres.Count())
                            {
                                Console.WriteLine("\nInvalid id");
                                Console.ReadLine();
                                break;
                            }
                            else if(newDiscGanreId == 0)
                            {
                                Console.Clear();
                                Console.Write("Enter ganre name: ");
                                string newDiscGanreName = Console.ReadLine();
                                newDiscGanre = new Ganre() { Name = newDiscGanreName };
                                db.Ganres.Add(newDiscGanre);
                                db.SaveChanges();
                            }
                            else
                            {
                                newDiscGanre = db.Ganres.ToArray()[newDiscGanreId - 1];
                            }

                            Console.Clear();
                            Console.WriteLine(new string('-', 30));
                            Console.WriteLine("0 - Add new Author");
                            for(int i = 0; i < db.Authors.Count(); i++)
                            {
                                Console.WriteLine($"{i + 1,-4}{db.Authors.ToArray()[i].Name,-12}{db.Authors.ToArray()[i].Surname,-14}");
                            }
                            Console.WriteLine(new string('-', 30));
                            Console.Write("Choose author: ");
                            int newDiscAuthorId = Convert.ToInt32(Console.ReadLine());
                            if(newDiscAuthorId < 0 || newDiscAuthorId > db.Authors.Count())
                            {
                                Console.WriteLine("\nInvalid id");
                                Console.ReadLine();
                                break;
                            }
                            else if(newDiscAuthorId == 0)
                            {
                                Console.Clear();
                                Console.Write("Enter author name: ");
                                string newDiscAuthorName = Console.ReadLine();
                                Console.WriteLine("Enter author surname: ");
                                string newDiscAuthorSurname = Console.ReadLine();
                                newDiscAuthor = new Author() { Name = newDiscAuthorName, Surname = newDiscAuthorSurname };
                                db.Authors.Add(newDiscAuthor);
                                db.SaveChanges();
                            }
                            else
                            {
                                newDiscAuthor = db.Authors.ToArray()[newDiscAuthorId - 1];
                            }

                            Console.Clear();
                            Console.WriteLine(new string('-', 30));
                            Console.WriteLine("0 - Add new publisher");
                            for(int i = 0; i < db.Publishers.Count(); i++)
                            {
                                Console.WriteLine($"{i + 1,-4}{db.Publishers.ToArray()[i].Name}");
                            }
                            Console.WriteLine(new string('-', 30));
                            Console.Write("Choose publisher: ");
                            int newDiscPublisherId = Convert.ToInt32(Console.ReadLine());
                            if(newDiscPublisherId < 0 || newDiscPublisherId > db.Publishers.Count())
                            {
                                Console.WriteLine("\nInvalid id");
                                Console.ReadLine();
                                break;
                            }
                            else if(newDiscPublisherId == 0)
                            {
                                Console.Clear();
                                Console.Write("Enter publisher name: ");
                                string newDiscPublisherName = Console.ReadLine();
                                newDiscPublisher = new Publisher() { Name = newDiscPublisherName };
                                db.Publishers.Add(newDiscPublisher);
                                db.SaveChanges();
                            }
                            else
                            {
                                newDiscPublisher = db.Publishers.ToArray()[newDiscPublisherId - 1];
                            }

                            Console.Clear();
                            Console.Write("Enter cost: ");
                            double newDiscCost = Convert.ToDouble(Console.ReadLine());
                            Console.Write("Enter Price: ");
                            double newDiscPrice = Convert.ToDouble(Console.ReadLine());
                            Console.Write("Enter amount: ");
                            int newDiscAmount = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Enter songs count: ");
                            int newDiscSongsCount = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Enter release date: ");
                            DateTime dt = Convert.ToDateTime(Console.ReadLine());
                            DateOnly newDiscReleaseDate = new DateOnly(dt.Year, dt.Month, dt.Day);

                            Disc newDisc = new Disc() { Name = newDiscName, Ganre = newDiscGanre, Author = newDiscAuthor, Publisher = newDiscPublisher, Cost = newDiscCost, Price = newDiscPrice, Amount = newDiscAmount, SongsCount = newDiscSongsCount, ReleaseDate = newDiscReleaseDate };
                            db.Discs.Add(newDisc);
                            db.SaveChanges();

                            Console.Clear();
                            Console.WriteLine("Disc was added successfully");
                            Console.ReadLine();
                        }
                        break;
                    case 3:
                        if (currentUser == null || currentUser.PermissionLevel == 0)
                        {
                            Console.WriteLine("\nYou don't have permission");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine($"{"Id",-5}{"Name",-20}{"Ganre",-15}{"Author",-20}{"Publisher",-20}{"Release Date",-15}{"Songs",-8}{"Price",-8}{"Amount",-8}");
                            Console.WriteLine(new string('-', 117));
                            Disc[] allDiscs = db.Discs.ToArray();
                            for(int i = 0;i < db.Discs.Count(); i++)
                            {
                                Console.WriteLine($"{i,-5}{allDiscs[i].Name,-20}{allDiscs[i].Ganre.Name,-15}{allDiscs[i].Author.Name,-10}{allDiscs[i].Author.Surname,-10}{allDiscs[i].Publisher.Name,-20}{allDiscs[i].ReleaseDate,-15}{allDiscs[i].SongsCount,-8}{allDiscs[i].Price.ToString("F2"),-8}{allDiscs[i].Amount,-8}");
                            }
                            Console.WriteLine(new string('-', 117));
                            Console.Write("Enter disc id: ");
                            int discToRemoveId = Convert.ToInt32(Console.ReadLine());
                            if(discToRemoveId < 0 || discToRemoveId >= allDiscs.Length)
                            {
                                Console.WriteLine("\nInvalid id");
                                Console.ReadLine();
                                break;
                            }
                            else
                            {
                                db.Remove(allDiscs[discToRemoveId]);
                                db.SaveChanges();
                                Console.Clear();
                                Console.WriteLine("Disc was removed successfully");
                                Console.ReadLine();
                            }
                        }
                        break;
                    case 4:
                        if (currentUser == null || currentUser.PermissionLevel == 0)
                        {
                            Console.WriteLine("\nYou don't have permission");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine($"{"id",-5}{"Name",-20}{"Discount",-10}{"Start date",-12}{"End date",-12}");
                            Console.WriteLine(new string('-',60));
                            Sale[] allSales = db.Sales.ToArray();
                            if(allSales.Length == 0) Console.WriteLine("No sales are avaliable");
                            else
                            {
                                for(int i = 0; i < allSales.Length; i++)
                                {
                                    Sale s = allSales[i];
                                    Console.WriteLine($"{i,-5}{s.Name,-20}{s.Discount,-10}{s.StartDate,-12}{s.EndDate,-12}");
                                }
                            }
                            Console.WriteLine(new string('-', 60));
                            Console.WriteLine("1 - Add new sale");
                            Console.WriteLine("2 - Remove sale");
                            Console.WriteLine(new string('-', 60));
                            Console.Write("Choose option: ");
                            option = Convert.ToInt32(Console.ReadLine());
                            switch (option)
                            {
                                case 1:
                                    Console.Clear();
                                    Console.Write("Enter sale name: ");
                                    string newSaleName = Console.ReadLine();
                                    Console.Write("Enter discount: ");
                                    int newSaleDiscount = Convert.ToInt32(Console.ReadLine());

                                    DateTime dt;
                                    Console.Write("Enter start date: ");
                                    dt = Convert.ToDateTime(Console.ReadLine());
                                    DateOnly newSaleStartDate = new DateOnly(dt.Year, dt.Month, dt.Day);
                                    Console.Write("Enter end date: ");
                                    dt = Convert.ToDateTime(Console.ReadLine());
                                    DateOnly newSaleEndDate = new DateOnly(dt.Year, dt.Month, dt.Day);

                                    Sale newSale = new Sale() { Name = newSaleName, Discount = newSaleDiscount, StartDate = newSaleStartDate, EndDate = newSaleEndDate };
                                    db.Sales.Add(newSale);
                                    db.SaveChanges();

                                    Console.Clear();

                                    Console.WriteLine($"{"Id",-5}{"Name",-20}{"Ganre",-15}{"Author",-20}{"Publisher",-20}{"Release Date",-15}{"Songs",-8}{"Price",-8}{"Amount",-8}");
                                    Console.WriteLine(new string('-', 117));
                                    Disc[] allDiscs = db.Discs.ToArray();
                                    for (int i = 0; i < db.Discs.Count(); i++)
                                    {
                                        Console.WriteLine($"{i + 1,-5}{allDiscs[i].Name,-20}{allDiscs[i].Ganre.Name,-15}{allDiscs[i].Author.Name,-10}{allDiscs[i].Author.Surname,-10}{allDiscs[i].Publisher.Name,-20}{allDiscs[i].ReleaseDate,-15}{allDiscs[i].SongsCount,-8}{allDiscs[i].Price.ToString("F2"),-8}{allDiscs[i].Amount,-8}");
                                    }
                                    Console.WriteLine(new string('-', 117));

                                    int discId = -1;
                                    while(discId != 0)
                                    {
                                        Console.Write("Enter disc id: ");
                                        discId = Convert.ToInt32(Console.ReadLine());
                                        if (discId < 0 || discId > allDiscs.Length)
                                        {
                                            Console.WriteLine("Invalid id");
                                            Console.ReadLine();
                                        }
                                        else
                                        {
                                            if(discId != 0) newSale.Discs.Add(allDiscs[discId - 1]);
                                        }
                                    }
                                    db.SaveChanges();
                                    Console.Clear();
                                    Console.WriteLine("Sale was added successfully");
                                    Console.ReadLine();
                                    break;
                                case 2:
                                    Console.Write("\nEnter sale id: ");
                                    int saleToRemoveId = Convert.ToInt32(Console.ReadLine());
                                    Sale saleToRemove = allSales[saleToRemoveId];
                                    db.Sales.Remove(saleToRemove);
                                    db.SaveChanges();
                                    Console.Clear();
                                    Console.WriteLine("Sale was removed successfully");
                                    Console.ReadLine();
                                    break;
                            }
                        }
                        break;
                }
            }
            break;
        case 2:
            if(currentUser == null)
            {
                Console.Write("\nTo view your cart you have to log in");
                Console.ReadLine();
                break;
            }
            Console.Clear();
            Console.WriteLine($"{"Id",-5}{"Name",-20}{"Ganre",-15}{"Author",-20}{"Publisher",-20}{"Release Date",-15}{"Songs",-8}{"Price",-8}{"Amount",-8}");
            Console.WriteLine(new string('-', 117));
            ShelvedDiscs[] shelvedDiscs = currentUser.ShelvedDiscs.ToArray();
            if (shelvedDiscs.Length == 0) Console.WriteLine("Your cart is empty");
            else
            {
                for(int i = 0; i < shelvedDiscs.Length; i++)
                {
                    Console.Write($"{i,-5}{shelvedDiscs[i].Disc.Name,-20}{shelvedDiscs[i].Disc.Ganre.Name,-15}{shelvedDiscs[i].Disc.Author.Name,-10}{shelvedDiscs[i].Disc.Author.Surname,-10}{shelvedDiscs[i].Disc.Publisher.Name,-20}{shelvedDiscs[i].Disc.ReleaseDate,-15}{shelvedDiscs[i].Disc.SongsCount,-8}");
                    if (shelvedDiscs[i].Disc.Sales.Count() == 0)
                    {
                        Console.Write($"{shelvedDiscs[i].Disc.Price.ToString("F2"),-8}");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write($"{(shelvedDiscs[i].Disc.Price / 100 * (100 - shelvedDiscs[i].Disc.Sales.Max(s => s.Discount))).ToString("F2"),-8}");
                        Console.ResetColor();
                    }
                    Console.WriteLine($"{shelvedDiscs[i].Amount,-8}");
                }
            }
            Console.WriteLine(new string('-', 117));
            Console.WriteLine("1 - Remove disc from your cart");
            Console.WriteLine("2 - Buy cart");
            Console.WriteLine(new string('-', 117));
            option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 0:
                    break;
                case 1:
                    if(shelvedDiscs.Length == 0)
                    {
                        Console.WriteLine("\nYour cart is empty");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.Write("\nEnter disc id: ");
                        int discToRemoveId = Convert.ToInt32(Console.ReadLine());
                        if(discToRemoveId < 0 || discToRemoveId >= shelvedDiscs.Length)
                        {
                            Console.WriteLine("\nInvalid id");
                            Console.ReadLine();
                        }
                        else
                        {
                            ShelvedDiscs discToRemove = shelvedDiscs[discToRemoveId];
                            discToRemove.Disc.Amount += discToRemove.Amount;
                            db.ShelvedDiscs.Remove(discToRemove);
                            db.SaveChanges();
                            Console.Clear();
                            Console.WriteLine("Disc was successfully removed from your cart");
                            Console.ReadLine();
                        }
                    }
                    break;
                case 2:
                    foreach(ShelvedDiscs sd in shelvedDiscs)
                    {
                        sd.Disc.Sold += sd.Amount;
                        double price;
                        if (sd.Disc.Sales.Count() == 0) price = sd.Disc.Price;
                        else price = sd.Disc.Price / 100 * (100 - sd.Disc.Sales.Max(s => s.Discount));
                        Purchase purchase = new Purchase() { Disc = sd.Disc, Amount = sd.Amount, PriceForOne = price, FinalPrice = price * sd.Amount, User = currentUser };
                        db.Purchases.Add(purchase);
                        db.ShelvedDiscs.Remove(sd);
                    }
                    db.SaveChanges();
                    break;
            }
            break;
        case 3:
            if (currentUser == null)
            {
                Console.Write("\nTo view your purchase history you have to log in");
                Console.ReadLine();
                break;
            }
            Console.Clear();
            Console.WriteLine($"{"Id",-5}{"Name",-20}{"Ganre",-12}{"Author",-20}{"Publisher",-20}{"Release Date",-15}{"Songs",-8}{"Price",-14}{"Amount"}");
            Console.WriteLine(new string('-', 120));            
            Purchase[] purchases = currentUser.Purchases.ToArray();
            if(purchases.Length == 0) Console.WriteLine("You haven't made any purchases yet");
            else for(int i = 0; i < purchases.Length; i++)
            {
                Purchase p = purchases[i];
                Console.WriteLine($"{i,-5}{p.Disc.Name,-20}{p.Disc.Ganre.Name,-12}{p.Disc.Author.Name,-10}{p.Disc.Author.Surname,-10}{p.Disc.Publisher.Name,-20}{p.Disc.ReleaseDate,-15}{p.Disc.SongsCount,-8}{p.PriceForOne.ToString("F2"),-6}|{p.FinalPrice.ToString("F2"),-7}{p.Amount}");
            }
            Console.WriteLine(new string('-', 120));
            Console.ReadLine();
            break;
        case 4:
            if (currentUser != null) break;
            Console.Clear();
            Console.Write("Do you have an account(Yes/No)?\t");
            string answer = Console.ReadLine();
            if(answer.ToLower() == "yes")
            {
                Console.Clear();
                Console.Write("Enter your login: ");
                string login = Console.ReadLine();
                Console.Write("Enter your password: ");
                string password = Console.ReadLine();

                User? userToEnter = db.Users.Where(u => u.Login == login && u.Password == password).FirstOrDefault();
                if(userToEnter == null) Console.WriteLine("\nCannot log into account");
                else
                {
                    currentUser = userToEnter;
                    Console.WriteLine("\nLogged in successfully");                    
                }
                Console.ReadLine();
            }
            if(answer.ToLower() == "no")
            {
                Console.Clear();
                Console.Write("Create your login: ");
                string login = Console.ReadLine();
                Console.Write("Create your password: ");
                string password = Console.ReadLine();

                if (password.Length < 8) Console.WriteLine("\nYour password is too short");
                else if (password.Length > 24) Console.WriteLine("\nYour password is too long");
                else if (login.Length < 3) Console.WriteLine("\nYour login is too short");
                else if (login.Length > 25) Console.WriteLine("\nYour login is too long");
                else
                {
                    User? userToCreate = db.Users.Where(u => u.Login == login).FirstOrDefault();
                    if(userToCreate != null) Console.WriteLine("\nUser with this login already exists");
                    else
                    {
                        userToCreate = new User { Login = login, Password = password };
                        db.Users.Add(userToCreate);
                        db.SaveChanges();
                        currentUser = userToCreate;
                        Console.WriteLine("\nUser created successfully");
                    }
                }
                Console.ReadLine();
            }
            break;
    }
} while (running);