using _015_DapperTwoTables;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

string connectionString = "Data Source=403-8\\MSSQLSERVERSTEP; Initial Catalog = DapperProductCategoryDB; User ID = sa; Password = 1; TrustServerCertificate=True;";

using IDbConnection db = new SqlConnection(connectionString);
db.Open();

//string query = "INSERT INTO Category(Name) VALUES(@name)";
//db.Execute(query, new Category { Name = "Food" });

//string query = "INSERT INTO Product(Title, Price, Description, CategoryId) VALUES(@title, @price, @description, @categoryId)";
//db.Execute(query, new Product
//{
//    Title = "Burger",
//    Price = 8,
//    Description = "",
//    CategoryId = 2
//});


//string query = "SELECT * FROM Product WHERE CategoryId = @categoryId";
//Product? res = db.Query<Product>(query, new {categoryId = 1}).FirstOrDefault();

//Console.WriteLine($"{res.Title,-15}{res.Price,-8}$ {res.CategoryId}");


string query = "SELECT * FROM Category WHERE id = @id; SELECT * FROM Product WHERE CategoryId = @id";

var results = db.QueryMultiple(query, new { id = 1 });

Category? category = results.Read<Category>().FirstOrDefault();
List<Product>? products = results.Read<Product>().ToList();

if (category != null && products != null)
{
    category.Products = products;
    foreach(Product product in products)
    {
        product.Category = category;
    }
}

foreach(Product product in products)
{
    Console.WriteLine($"{product.Title,-15}{product.Price,-8}$ {product.Category.Name}");
}