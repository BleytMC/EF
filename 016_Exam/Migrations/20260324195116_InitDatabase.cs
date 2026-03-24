using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace _016_Exam.Migrations
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ganres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ganres", x => x.Id);
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
                name: "Sales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Discount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.Id);
                    table.CheckConstraint("Discount", "Discount > 0 AND Discount < 100");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: false),
                    PermissionLevel = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Discs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cost = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    PublisherId = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    GanreId = table.Column<int>(type: "int", nullable: false),
                    ReleaseDate = table.Column<DateOnly>(type: "date", nullable: false),
                    SongsCount = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Sold = table.Column<int>(type: "int", nullable: false),
                    Shelved = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discs", x => x.Id);
                    table.CheckConstraint("Amount", "Amount >= 0");
                    table.CheckConstraint("Cost", "Cost >= 0");
                    table.CheckConstraint("Price", "Price > Cost");
                    table.CheckConstraint("Shelved", "Shelved >= 0");
                    table.CheckConstraint("Sold", "Sold >= 0");
                    table.ForeignKey(
                        name: "FK_Discs_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Discs_Ganres_GanreId",
                        column: x => x.GanreId,
                        principalTable: "Ganres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Discs_Publishers_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "Publishers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DiscSale",
                columns: table => new
                {
                    DiscsId = table.Column<int>(type: "int", nullable: false),
                    SalesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscSale", x => new { x.DiscsId, x.SalesId });
                    table.ForeignKey(
                        name: "FK_DiscSale_Discs_DiscsId",
                        column: x => x.DiscsId,
                        principalTable: "Discs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DiscSale_Sales_SalesId",
                        column: x => x.SalesId,
                        principalTable: "Sales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Purchases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    DiscId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    PriceForOne = table.Column<double>(type: "float", nullable: false),
                    FinalPrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchases", x => x.Id);
                    table.CheckConstraint("Amount1", "Amount > 0");
                    table.CheckConstraint("FinalPrice", "FinalPrice >= PriceForOne");
                    table.CheckConstraint("PriceForOne", "PriceForOne > 0");
                    table.ForeignKey(
                        name: "FK_Purchases_Discs_DiscId",
                        column: x => x.DiscId,
                        principalTable: "Discs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Purchases_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShelvedDiscs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    DiscId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShelvedDiscs", x => x.Id);
                    table.CheckConstraint("Amount2", "Amount >= 0");
                    table.ForeignKey(
                        name: "FK_ShelvedDiscs_Discs_DiscId",
                        column: x => x.DiscId,
                        principalTable: "Discs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShelvedDiscs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Name", "Surname" },
                values: new object[,]
                {
                    { 1, "John", "Smith" },
                    { 2, "Emma", "Johnson" },
                    { 3, "Michael", "Brown" },
                    { 4, "Olivia", "Davis" },
                    { 5, "William", "Miller" },
                    { 6, "Sophia", "Wilson" }
                });

            migrationBuilder.InsertData(
                table: "Ganres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Rock" },
                    { 2, "Pop" },
                    { 3, "Jazz" },
                    { 4, "Hip-Hop" },
                    { 5, "Classical" }
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Universal Music" },
                    { 2, "Sony Music" },
                    { 3, "Warner Music" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Login", "Password", "PermissionLevel" },
                values: new object[] { 1, "a", "1", 1 });

            migrationBuilder.InsertData(
                table: "Discs",
                columns: new[] { "Id", "Amount", "AuthorId", "Cost", "GanreId", "Name", "Price", "PublisherId", "ReleaseDate", "Shelved", "Sold", "SongsCount" },
                values: new object[,]
                {
                    { 1, 50, 1, 5.2000000000000002, 1, "Rock Legends", 15.9, 1, new DateOnly(2010, 5, 12), 0, 0, 12 },
                    { 2, 80, 2, 4.0, 2, "Pop Hits", 12.5, 2, new DateOnly(2015, 3, 8), 0, 0, 10 },
                    { 3, 40, 3, 6.5, 3, "Jazz Night", 18.0, 3, new DateOnly(2008, 11, 21), 0, 0, 8 },
                    { 4, 70, 4, 3.7999999999999998, 4, "Hip-Hop Beats", 11.0, 2, new DateOnly(2020, 7, 15), 0, 0, 14 },
                    { 5, 30, 5, 7.5, 5, "Classic Collection", 20.0, 3, new DateOnly(2000, 1, 1), 0, 0, 20 },
                    { 6, 55, 6, 5.0, 1, "Rock Arena", 14.0, 1, new DateOnly(2012, 6, 18), 0, 0, 11 },
                    { 7, 75, 1, 4.2000000000000002, 2, "Pop Dreams", 13.0, 2, new DateOnly(2016, 4, 10), 0, 0, 13 },
                    { 8, 35, 2, 6.0, 3, "Smooth Jazz", 17.5, 3, new DateOnly(2009, 2, 25), 0, 0, 7 },
                    { 9, 90, 3, 3.5, 4, "Street Beats", 10.5, 1, new DateOnly(2021, 8, 5), 0, 0, 15 },
                    { 10, 20, 4, 8.0, 5, "Symphony Best", 22.0, 2, new DateOnly(1995, 12, 12), 0, 0, 25 },
                    { 11, 45, 5, 5.0999999999999996, 1, "Rock Energy", 15.0, 3, new DateOnly(2011, 3, 3), 0, 0, 12 },
                    { 12, 85, 6, 4.4000000000000004, 2, "Pop Star", 13.9, 1, new DateOnly(2017, 9, 9), 0, 0, 11 },
                    { 13, 25, 1, 6.7999999999999998, 3, "Jazz Classics", 19.0, 2, new DateOnly(2007, 6, 14), 0, 0, 9 },
                    { 14, 95, 2, 3.8999999999999999, 4, "Rap Kings", 12.0, 3, new DateOnly(2022, 2, 2), 0, 0, 16 },
                    { 15, 15, 3, 7.7999999999999998, 5, "Orchestra Gold", 21.5, 1, new DateOnly(1998, 10, 30), 0, 0, 18 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Discs_AuthorId",
                table: "Discs",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Discs_GanreId",
                table: "Discs",
                column: "GanreId");

            migrationBuilder.CreateIndex(
                name: "IX_Discs_PublisherId",
                table: "Discs",
                column: "PublisherId");

            migrationBuilder.CreateIndex(
                name: "IX_DiscSale_SalesId",
                table: "DiscSale",
                column: "SalesId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_DiscId",
                table: "Purchases",
                column: "DiscId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_UserId",
                table: "Purchases",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ShelvedDiscs_DiscId",
                table: "ShelvedDiscs",
                column: "DiscId");

            migrationBuilder.CreateIndex(
                name: "IX_ShelvedDiscs_UserId",
                table: "ShelvedDiscs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Login",
                table: "Users",
                column: "Login",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiscSale");

            migrationBuilder.DropTable(
                name: "Purchases");

            migrationBuilder.DropTable(
                name: "ShelvedDiscs");

            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "Discs");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Ganres");

            migrationBuilder.DropTable(
                name: "Publishers");
        }
    }
}
