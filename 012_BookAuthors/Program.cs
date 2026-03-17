using _012_BookAuthors;
using Microsoft.EntityFrameworkCore;

using ApplicationDbContext db = new ApplicationDbContext();

// 1 Всі книжки в алфавітному порядку

//var books = from b in db.Books
//            orderby b.Name
//            select b;

//foreach(Book book in books)
//{
//    Console.WriteLine($"Name: {book.Name,-30}Pages: {book.Pages,-5}Price: {book.Price}$");
//}


// 2 Всі автори

//var authors = from a in db.Authors
//              orderby a.FirstName
//              select a;

//foreach(Author author in authors)
//{
//    Console.WriteLine($"Name: {author.FirstName,-15}Surname: {author.LastName,-20}");
//}


// 3 Автори та їх книги

//var authorsAndBooks = from a in db.Authors.Include(a => a.Books)
//                      select a;

//foreach (Author author in authorsAndBooks)
//{
//    Console.WriteLine($"Name: {author.FirstName,-15}Surname: {author.LastName,-20}");
//    foreach(Book book in author.Books) Console.WriteLine($"\t{book.Name}");
//}


// 4 Книги та їх видавці

//var booksAndPublishers = from b in db.Books.Include(b => b.Publisher)
//                         select b;

//foreach(Book book in booksAndPublishers)
//{
//    Console.WriteLine($"Book: {book.Name,-30}Publisher: {book.Publisher.Name}");
//}


// 5 Автори ти всі видавці які видавали їх книги

//var authors = from a in db.Authors.Include(a => a.Books).ThenInclude(b => b.Publisher)
//              select a;

//foreach(Author author in authors)
//{
//    Console.WriteLine($"Name: {author.FirstName,-15}Surname: {author.LastName,-20}");
//    foreach(Book book in author.Books) Console.WriteLine($"\t{book.Publisher.Name}");
//}


// 6 Книжки за зростанням кількості сторінок

//var books = from b in db.Books
//            orderby b.Pages
//            select b;

//foreach(Book book in books)
//{
//    Console.WriteLine($"Title: {book.Name,-30}Pages: {book.Pages}");
//}


// 7 Книжки за спаданням кількості сторінок

//var books = from b in db.Books
//            orderby b.Pages descending
//            select b;

//foreach (Book book in books)
//{
//    Console.WriteLine($"Title: {book.Name,-30}Pages: {book.Pages}");
//}


// 8 Видавництво і всі книжки які воно видавало

//var publishers = from p in db.Publishers.Include(p => p.Books)
//                 select p;

//foreach(Publisher publisher in publishers)
//{
//    Console.WriteLine($"Name: {publisher.Name,-20}");
//    foreach(Book book in publisher.Books) Console.WriteLine($"\t{book.Name}");
//}


// 9 Всі видавництва

//var publishers = from p in db.Publishers
//                 select p;

//foreach(Publisher publisher in publishers) Console.WriteLine(publisher.Name);


// 10 Всі дані

//var authors = from a in db.Authors.Include(a => a.Books).ThenInclude(b => b.Publisher)
//              select a;

//foreach(Author author in authors)
//{
//    Console.WriteLine($"Name: {author.FirstName,-15}Surname: {author.LastName}");
//    foreach(Book book in author.Books) Console.WriteLine($"\tTitle: {book.Name,-30}Pages: {book.Pages,-7}Publisher: {book.Publisher.Name}");
//}