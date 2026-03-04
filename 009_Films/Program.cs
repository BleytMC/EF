using _009_Films;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

using ApplicationDbContext db = new ApplicationDbContext();


int choice;

bool choosing = false;

Studio? activeStudio = null;
Film? activeFilm = null;

do
{
    Console.Clear();
    if (activeStudio == null)
    {
        Console.WriteLine(new string('-', 25));
        foreach (Studio studio in db.Studios)
        {
            Console.WriteLine($"{studio.Id} - {studio.Name}");
        }
        Console.WriteLine(new string('-', 25));

        Console.WriteLine("\n1 - Add studio");
        Console.WriteLine("2 - Remove studio");
        Console.WriteLine("3 - Edit studio");

        Console.Write("\nChoose option: ");
        choice = Convert.ToInt32(Console.ReadLine());

        switch (choice)
        {
            case 1:
                Console.Write("Enter studio name: ");
                string studioName = Console.ReadLine();
                db.Studios.Add(new Studio() { Name = studioName });
                db.SaveChanges();
                break;
            case 2:
                Console.Write("Enter studio id: ");
                choice = Convert.ToInt32(Console.ReadLine());
                Studio? studioToRemove = db.Studios.Where(s => s.Id == choice).FirstOrDefault();
                if (studioToRemove == null)
                {
                    Console.WriteLine("Studio with this id does not exist");
                    Console.ReadLine();
                }
                else
                {
                    db.Studios.Remove(studioToRemove);
                    db.SaveChanges();
                }
                break;
            case 3:
                Console.Write("Enter studio id: ");
                choice = Convert.ToInt32(Console.ReadLine());
                Studio? studioToEdit = db.Studios.Where(s => s.Id == choice).Include(s => s.Films).FirstOrDefault();
                if(studioToEdit == null)
                {
                    Console.WriteLine("Studio with this id does not exist");
                    Console.ReadLine();
                }
                else
                {
                    activeStudio = studioToEdit;
                }
                break;
        }
    }
    else
    {
        if(activeFilm == null)
        {
            Console.WriteLine(new string('-', 25));
            foreach(Film film in activeStudio.Films)
            {
                Console.WriteLine($"{film.Id} - {film.Title}");
            }
            Console.WriteLine(new string('-', 25));

            Console.WriteLine("\n1 - Add film");
            Console.WriteLine("2 - Remove film");
            Console.WriteLine("3 - Edit actor");

            Console.Write("\nChoose option: ");
            choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter film name: ");
                    string filmName = Console.ReadLine();
                    db.Films.Add(new Film() { Title = filmName, Studio = activeStudio });
                    db.SaveChanges();
                    break;
                case 2:
                    Console.Write("Enter film id: ");
                    choice = Convert.ToInt32(Console.ReadLine());
                    Film? filmToRemove = db.Films.Where(f => f.Id == choice).Include(f => f.Actors).FirstOrDefault();
                    if(filmToRemove == null)
                    {
                        Console.WriteLine("Film with this id does not exist");
                        Console.ReadLine();
                    }
                    else
                    {
                        db.Films.Remove(filmToRemove);
                        db.SaveChanges();
                    }
                    break;
            }

            Film? bufFilm = db.Films.Where(f => f.Id == choice).Include(f => f.Actors).FirstOrDefault();
            if(bufFilm == null)
            {
                Console.WriteLine("Film with this id does not exist");
            }
            else
            {
                activeFilm = bufFilm;
            }
        }
        else
        {
            Console.Write("B ");
            choice = Convert.ToInt32(Console.ReadLine());
        }
    }
} while (choice != 0);