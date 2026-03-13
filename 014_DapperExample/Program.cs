using _014_DapperExample;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

string connectionString = "Data Source=403-8\\MSSQLSERVERSTEP; Initial Catalog = DapperProductDB; User ID = sa; Password = 1; TrustServerCertificate=True;";

using IDbConnection db = new SqlConnection(connectionString);
db.Open();

//var result = db.Query<string>("SELECT 'Hello Dapper'").Single();
//Console.WriteLine(result);

// 1

//string query = "INSERT INTO Product (Title, Price) VALUES('TV', 1299.99)";
//int res = db.Execute(query);
//Console.WriteLine(res);


// 2

//string title = "Mouse";
//double price = 2345.33;

//string query = "INSERT INTO Product (Title, Price) VALUES(@title, @price)";
//db.Execute(query, new { title, price });


// 3

//Product product = new Product()
//{
//    Title = "Phone",
//    Price = 1203.33f
//};

//string query = "INSERT INTO Product (Title, Price) VALUES(@title, @price)";
//db.Execute(query, product);


//string query = "INSERT INTO Product (Title, Price) VALUES(@title, @price)";
//int res = db.Execute(query, new object[]
//{
//    new {title = "Headphones", price = 32.33},
//    new {title = "Laptop", price = 656.55},
//    new {title = "Tablet", price = 233.22}
//});

//Console.WriteLine(res);


//string query = "SELECT * FROM Product";
//List<Product> products = db.Query<Product>(query).ToList();

//foreach(Product product in products) Console.WriteLine($"{product.Title,-15}{product.Price,-9}$");


//string query = "SELECT * FROM Product WHERE Id = @id";
//Product? product = db.Query<Product>(query, new { id = 1 }).FirstOrDefault();

//Console.WriteLine($"{product.Title,-15}{product.Price,-9}$");


//string query = "UPDATE Product SET Price = @price WHERE Id = @id";
//int res = db.Execute(query, new { id = 1, price = 10000 });

//Console.WriteLine(res);


//string query = "DELETE FROM Product WHERE Id = @id";
//int res = db.Execute(query, new { id = 1 });

//Console.WriteLine(res);