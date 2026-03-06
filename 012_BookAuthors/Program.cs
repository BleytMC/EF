using _012_BookAuthors;

using ApplicationDbContext db = new ApplicationDbContext();

// Всі книжки в алфавітному порядку

var books = from b in db.Books
            orderby b.Name
            select b;

foreach(var book in books)
{
    Console.WriteLine($"Name: {book.Name,-30}Pages: {book.Pages,-5}Price: {book.Price}$");
}