using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KisiselBlog.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    ShortDescription = table.Column<string>(type: "TEXT", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: false),
                    GifUrl = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Category = table.Column<string>(type: "TEXT", nullable: false),
                    TechStack = table.Column<string>(type: "TEXT", nullable: false),
                    IsFeatured = table.Column<bool>(type: "INTEGER", nullable: false),
                    FeaturesJson = table.Column<string>(type: "TEXT", nullable: true),
                    TechnologiesJson = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Category", "CreatedDate", "Description", "FeaturesJson", "GifUrl", "ImageUrl", "IsFeatured", "ShortDescription", "TechStack", "TechnologiesJson", "Title" },
                values: new object[,]
                {
                    { 1, "frontend", new DateTime(2025, 1, 6, 16, 15, 45, 413, DateTimeKind.Local).AddTicks(8058), "ASP.NET Core MVC kullanılarak geliştirilen modern ve responsive bir kişisel blog sitesi.", null, "/images/proje1.gif", "/images/proje1.png", true, "ASP.NET Core MVC ile geliştirilmiş modern blog sitesi", "ASP.NET Core MVC, Bootstrap 5, Entity Framework Core", null, "Kişisel Blog Projesi" },
                    { 2, "all", new DateTime(2025, 2, 6, 16, 15, 45, 413, DateTimeKind.Local).AddTicks(8074), "React ve .NET Core Web API kullanılarak geliştirilen modern bir görev yönetim uygulaması.", null, "/images/proje2.gif", "/images/proje2.png", true, "React ve .NET Core Web API ile geliştirilmiş görev yönetim uygulaması", "React.js, .NET Core Web API, Entity Framework Core", null, "To-Do List Uygulaması" },
                    { 3, "web", new DateTime(2024, 12, 6, 16, 15, 45, 413, DateTimeKind.Local).AddTicks(8076), "ASP.NET Core backend ve Angular frontend ile geliştirilmiş, tam kapsamlı bir e-ticaret platformu.", null, "/images/proje3.gif", "/images/proje3.png", false, "ASP.NET Core ve Angular ile geliştirilmiş e-ticaret platformu", "ASP.NET Core, Angular, MS SQL, Redis", null, "E-Ticaret Platformu" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
