using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace _012_BookAuthors.Migrations
{
    /// <inheritdoc />
    public partial class InitDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pages = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    PublisherId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.CheckConstraint("Pages", "Pages >= 0");
                    table.ForeignKey(
                        name: "FK_Books_Publishers_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "Publishers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookAuthors",
                columns: table => new
                {
                    AuthorsId = table.Column<int>(type: "int", nullable: false),
                    BooksId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookAuthors", x => new { x.AuthorsId, x.BooksId });
                    table.ForeignKey(
                        name: "FK_BookAuthors_Authors_AuthorsId",
                        column: x => x.AuthorsId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookAuthors_Books_BooksId",
                        column: x => x.BooksId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "John", "Smith" },
                    { 2, "Michael", "Johnson" },
                    { 3, "David", "Brown" },
                    { 4, "James", "Williams" },
                    { 5, "Robert", "Jones" },
                    { 6, "William", "Garcia" },
                    { 7, "Richard", "Miller" },
                    { 8, "Joseph", "Davis" },
                    { 9, "Thomas", "Rodriguez" },
                    { 10, "Charles", "Martinez" },
                    { 11, "Daniel", "Hernandez" },
                    { 12, "Matthew", "Lopez" },
                    { 13, "Anthony", "Gonzalez" },
                    { 14, "Mark", "Wilson" },
                    { 15, "Donald", "Anderson" }
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Penguin Books" },
                    { 2, "HarperCollins" },
                    { 3, "Simon & Schuster" },
                    { 4, "Oxford Press" },
                    { 5, "Cambridge Press" },
                    { 6, "Springer" },
                    { 7, "Packt Publishing" },
                    { 8, "Manning Publications" },
                    { 9, "O’Reilly Media" },
                    { 10, "No Starch Press" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Name", "Pages", "Price", "PublisherId" },
                values: new object[,]
                {
                    { 1, "C# Fundamentals", 350, 35.5f, 9 },
                    { 2, ".NET Deep Dive", 420, 40f, 9 },
                    { 3, "Entity Framework Guide", 300, 32.2f, 8 },
                    { 4, "ASP.NET Core Web", 500, 45f, 8 },
                    { 5, "LINQ in Action", 280, 28.9f, 7 },
                    { 6, "Algorithms Basics", 610, 55.5f, 6 },
                    { 7, "Data Structures", 540, 50f, 6 },
                    { 8, "Clean Code Guide", 450, 42.3f, 10 },
                    { 9, "Design Patterns", 395, 39.9f, 10 },
                    { 10, "Microservices Architecture", 370, 37.5f, 7 },
                    { 11, "Docker for Developers", 260, 29.5f, 7 },
                    { 12, "Kubernetes Essentials", 330, 34f, 7 },
                    { 13, "AI Basics", 410, 44.5f, 5 },
                    { 14, "Machine Learning Intro", 390, 41f, 5 },
                    { 15, "Deep Learning Guide", 520, 52f, 5 },
                    { 16, "Python for Data Science", 360, 36f, 4 },
                    { 17, "Statistics Essentials", 300, 31f, 4 },
                    { 18, "Game Development Basics", 480, 43.7f, 3 },
                    { 19, "Computer Graphics", 510, 49.5f, 2 },
                    { 20, "Operating Systems", 620, 58.9f, 1 }
                });

            migrationBuilder.InsertData(
                table: "BookAuthors",
                columns: new[] { "AuthorsId", "BooksId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 17 },
                    { 2, 1 },
                    { 2, 2 },
                    { 3, 2 },
                    { 3, 3 },
                    { 4, 3 },
                    { 4, 4 },
                    { 5, 5 },
                    { 5, 18 },
                    { 6, 6 },
                    { 6, 7 },
                    { 7, 7 },
                    { 7, 19 },
                    { 8, 8 },
                    { 9, 9 },
                    { 9, 20 },
                    { 10, 10 },
                    { 11, 11 },
                    { 12, 12 },
                    { 13, 13 },
                    { 13, 14 },
                    { 14, 14 },
                    { 14, 15 },
                    { 15, 16 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthors_BooksId",
                table: "BookAuthors",
                column: "BooksId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_PublisherId",
                table: "Books",
                column: "PublisherId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookAuthors");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Publishers");
        }
    }
}
