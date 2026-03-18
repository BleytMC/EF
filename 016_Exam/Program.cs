using _016_Exam;
using _016_Exam.Models;
using Microsoft.EntityFrameworkCore;

using ApplicationDbContext db = new ApplicationDbContext();

User? currentUser = null;

bool running = true;

do
{
    Console.Clear();
    if(currentUser == null) Console.WriteLine("No user",-25);
    else Console.WriteLine(currentUser.Login,-25);
    Console.WriteLine(new string('-', 50));
    Console.WriteLine("1 - View all discs");
    Console.WriteLine("2 - View your cart");
    if(currentUser == null) Console.WriteLine("3 - Log in");
    Console.WriteLine(new string('-', 50));
    Console.Write("Choose option: ");
    int option = Convert.ToInt32(Console.ReadLine());
    switch (option)
    {
        case 0:
            running = false;
            break;
        case 2:
            if(currentUser == null)
            {
                Console.Write("\nTo view your cart you have to log in");
                Console.ReadLine();
                break;
            }
            Console.Clear();
            Console.WriteLine($"{"Id",-5}{"Name",-15}{"Ganre",-10}{"Author",-30}{"Publisher",-15}{"Price",-8}{"Amount",-8}{"Final Price",-15}");
            Console.WriteLine(new string('-', 106);
            if(currentUser.Purchases.Count == 0) Console.WriteLine("Your cart is empty");
            else
            {
                ShelvedDiscs[] shelvedDiscs = currentUser.ShelvedDiscs.ToArray();
                for(int i = 0; i < shelvedDiscs.Length; i++)
                {
                    Console.WriteLine($"{i,-5}{shelvedDiscs[i].Disc.Name,-15}{shelvedDiscs[i].Disc.Ganre.Name,-10}{shelvedDiscs[i].Disc.Author.Name,-15}{shelvedDiscs[i].Disc.Author.Surname,-15}{shelvedDiscs[i].Disc.Publisher.Name,-15}{shelvedDiscs[i].Disc.Price,-8}{shelvedDiscs[i].Amount,-8}{shelvedDiscs[i].Disc.Price * shelvedDiscs[i].Amount,-15}");
                }
            }
            Console.WriteLine(new string('-', 106));
            Console.ReadLine();
            break;
        case 3:
            if (currentUser != null) break;
            Console.Clear();
            Console.Write("Do you have an account(Yes/No)?\t");
            string answer =Console.ReadLine();
            if(answer.ToLower() == "yes")
            {
                Console.Clear();
                Console.Write("Enter your login: ");
                string login = Console.ReadLine();
                Console.Write("Enter your password: ");
                string password = Console.ReadLine();

                User? userToEnter = db.Users.Where(u => u.Login == login && u.Password == password).Include(u => u.ShelvedDiscs).FirstOrDefault();
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
                    User? userToCreate = db.Users.Where(u => u.Login == login).Include(u => u.ShelvedDiscs).FirstOrDefault();
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