using _013_HW3;

using ApplicationDbContext db = new ApplicationDbContext();

Category? activeCategory = null;

int choice;
bool running = true;

do
{
    Console.Clear();
    if (activeCategory == null)
    {
        Console.WriteLine($"{"Id",-3} Title");
        Console.WriteLine(new string('-', 30));
        foreach (Category category in db.Categories) Console.WriteLine($"{category.Id,-3} {category.Title}");
        Console.WriteLine(new string('-', 30));
        Console.WriteLine("0 - Exit");
        Console.WriteLine("1 - Add category");
        Console.WriteLine("2 - Remove category");
        Console.WriteLine("3 - Edit category");
        Console.WriteLine(new string('-', 30));
        Console.Write("Enter option: ");
        choice = Convert.ToInt32(Console.ReadLine());
        switch (choice)
        {
            case 0:
                running = false;
                break;
            case 1:
                Console.Write("\nEnter category name: ");
                string categoryTitle = Console.ReadLine();
                Category categoryToAdd = new Category() { Title = categoryTitle };
                db.Categories.Add(categoryToAdd);
                db.SaveChanges();
                break;
            case 2:
                Console.Write("\nEnter category id: ");
                int categoryToRemoveId = Convert.ToInt32(Console.ReadLine());
                Category? categoryToRemove = db.Categories.Where(c => c.Id == categoryToRemoveId).FirstOrDefault();
                if(categoryToRemove != null)
                {
                    db.Categories.Remove(categoryToRemove);
                    db.SaveChanges();
                }
                else
                {
                    Console.WriteLine("\nCategory with this id does not exist");
                    Console.ReadLine();
                }
                break;
            case 3:
                Console.Write("\nEnter category id: ");
                int categoryToChooseId = Convert.ToInt32(Console.ReadLine());
                Category? categoryToChoose = db.Categories.Where(c => c.Id == categoryToChooseId).FirstOrDefault();
                if (categoryToChoose != null) activeCategory = categoryToChoose;
                else
                {
                    Console.WriteLine("\nCategory with this id does not exist");
                    Console.ReadLine();
                }
                break;
        }
    }
    else
    {
        Console.WriteLine($"{"Id",-3} {"Name",-15} Price");
        Console.WriteLine(new string('-', 30));
        foreach (Product product in activeCategory.Products) Console.WriteLine($"{product.Id,-3} {product.Name,-15} {product.Price}$");
        Console.WriteLine(new string('-', 30));
        Console.WriteLine("0 - Return");
        Console.WriteLine("1 - Add product");
        Console.WriteLine("2 - Remove product");
        Console.WriteLine(new string('-', 30));
        Console.Write("Enter option: ");
        choice = Convert.ToInt32(Console.ReadLine());
        switch (choice)
        {
            case 0:
                activeCategory = null;
                break;
            case 1:
                Console.Write("\nEnter product name: ");
                string productName = Console.ReadLine();
                Console.Write("Enter product price: ");
                float productPrice = Convert.ToSingle(Console.ReadLine());
                Product productToAdd = new Product() { Name = productName, Price = productPrice, Category = activeCategory };
                db.Products.Add(productToAdd);
                db.SaveChanges();
                break;
            case 2:
                Console.Write("\nEnter product id: ");
                int productToRemoveId = Convert.ToInt32(Console.ReadLine());
                Product? productToRemove = activeCategory.Products.Where(p => p.Id ==  productToRemoveId).FirstOrDefault();
                if(productToRemove != null)
                {
                    db.Products.Remove(productToRemove);
                    db.SaveChanges();
                }
                else
                {
                    Console.WriteLine("\nProduct with this id does not exist");
                    Console.ReadLine();
                }
                break;
        }
    }
} while (running);