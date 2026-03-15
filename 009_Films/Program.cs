using _009_Films;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

using ApplicationDbContext db = new ApplicationDbContext();


int choice;

bool viewingActors = false;

bool running = true;

Studio? activeStudio = null;
Film? activeFilm = null;

do
{
    Console.Clear();
    if (activeStudio == null)
    {
        if (viewingActors)
        {
            Console.WriteLine($"{"Id",-3}{"Name",-10}{"Surname",-15}");
            Console.WriteLine(new string('-', 25));
            foreach (Actor actor in db.Actors.Include(a => a.Films))
            {
                Console.WriteLine($"{actor.Id,-3}{actor.Name,-10}{actor.Surname,-15}");
                foreach (Film film in actor.Films) Console.WriteLine($"\t{film.Title}");
            }
            Console.WriteLine(new string('-', 25));

            Console.WriteLine("1 - Add actor");
            Console.WriteLine("2 - Remove actor");

            Console.Write("\nChoose option: ");
            choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 0:
                    viewingActors = false;
                    break;
                case 1:
                    Console.Write("\nEnter actor name: ");
                    string actorName = Console.ReadLine();
                    Console.Write("Enter actor surname: ");
                    string actorSurname = Console.ReadLine();
                    Actor actorToAdd = new Actor() { Name = actorName, Surname = actorSurname };
                    db.Actors.Add(actorToAdd);
                    db.SaveChanges();
                    break;
                case 2:
                    Console.Write("\nEnter actor id: ");
                    choice = Convert.ToInt32(Console.ReadLine());
                    Actor? actorToRemove = db.Actors.Where(a => a.Id == choice).FirstOrDefault();
                    if (actorToRemove == null)
                    {
                        Console.WriteLine("Actor with this id does not exist: ");
                        Console.ReadLine();
                    }
                    else
                    {
                        activeFilm.Actors.Remove(actorToRemove);
                        db.SaveChanges();
                    }
                    break;
            }

        }
        else
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
            Console.WriteLine("4 - View all actors");

            Console.Write("\nChoose option: ");
            choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 0:
                    running = false;
                    break;
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
                    if (studioToEdit == null)
                    {
                        Console.WriteLine("Studio with this id does not exist");
                        Console.ReadLine();
                    }
                    else
                    {
                        activeStudio = studioToEdit;
                    }
                    break;
                case 4:
                    viewingActors = true;
                    break;

            }
        }
    }
    else
    {
        Console.WriteLine(activeStudio.Name);
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
            Console.WriteLine("3 - Edit film");

            Console.Write("\nChoose option: ");
            choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 0:
                    activeStudio = null;
                    break;
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
                case 3:
                    Console.Write("Enter film id: ");
                    choice = Convert.ToInt32(Console.ReadLine());
                    Film? filmToEdit = db.Films.Where(f => f.Id == choice).Include(f => f.Actors).FirstOrDefault();
                    if(filmToEdit == null)
                    {
                        Console.WriteLine("Film with this id does not exist");
                        Console.ReadLine();
                    }
                    else
                    {
                        activeFilm = filmToEdit;
                    }
                        break;
            }
        }
        else
        {
            Console.WriteLine(activeFilm.Title);
            Console.WriteLine($"{"Id",-3}{"Name",-10}{"Surname",-15}");
            Console.WriteLine(new string('-', 25));
            foreach (Actor actor in activeFilm.Actors)
            {
                Console.WriteLine($"{actor.Id,-3}{actor.Name,-10}{actor.Surname,-15}");
            }
            Console.WriteLine(new string('-', 25));

            Console.WriteLine("\n1 - Add actor");
            Console.WriteLine("2 - Remove actor");

            Console.Write("\nChoose option: ");
            choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 0:
                    activeFilm = null;
                    break;
                case 1:
                    Console.Clear();
                    Console.WriteLine($"{"Id",-3}{"Name",-10}{"Surname",-15}");
                    Console.WriteLine(new string('-', 25));
                    foreach (Actor actor in db.Actors)
                    {
                        Console.WriteLine($"{actor.Id,-3}{actor.Name,-10}{actor.Surname,-15}");
                    }
                    Console.WriteLine(new string('-', 25));
                    Console.Write("\nEnter actor id: ");
                    choice = Convert.ToInt32(Console.ReadLine());
                    Actor? actorToLink = db.Actors.Where(a => a.Id == choice).FirstOrDefault();
                    if (actorToLink == null)
                    {
                        Console.WriteLine("Actor with this id does not exist: ");
                        Console.ReadLine();
                    }
                    else
                    {
                        activeFilm.Actors.Add(actorToLink);
                        db.SaveChanges();
                    }
                    break;
                case 2:
                    Console.Write("\nEnter actor id: ");
                    choice = Convert.ToInt32(Console.ReadLine());
                    Actor? actorToRemove = db.Actors.Where(a => a.Id == choice).FirstOrDefault();
                    if(actorToRemove == null)
                    {
                        Console.WriteLine("Actor with this id does not exist: ");
                        Console.ReadLine();
                    }
                    else
                    {
                        activeFilm.Actors.Remove(actorToRemove);
                        db.SaveChanges();
                    }
                    break;
            }
        }
    }
} while (running);