using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KisiselBlog.Migrations
{
    /// <inheritdoc />
    public partial class RemovedTechStack : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TechStack",
                table: "Projects");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FeaturesJson", "TechnologiesJson" },
                values: new object[] { "[\"Responsive tasar\\u0131m\",\"Modern UI/UX\",\"Blog yaz\\u0131 y\\u00F6netimi\",\"SEO uyumlu yap\\u0131\",\"Performans optimizasyonu\"]", "[\"ASP.NET Core MVC\",\"Bootstrap 5\",\"Entity Framework Core\",\"SQLite\",\"JavaScript/jQuery\"]" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FeaturesJson", "TechnologiesJson" },
                values: new object[] { "[\"Responsive tasar\\u0131m\",\"Modern UI/UX\",\"G\\u00F6rev y\\u00F6netimi\",\"SEO uyumlu yap\\u0131\",\"Performans optimizasyonu\"]", "[\"React.js\",\".NET Core Web API\",\"Entity Framework Core\",\"SQLite\",\"JavaScript/jQuery\"]" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FeaturesJson", "TechnologiesJson" },
                values: new object[] { "[\"Responsive tasar\\u0131m\",\"Modern UI/UX\",\"E-ticaret i\\u015Flevleri\",\"SEO uyumlu yap\\u0131\",\"Performans optimizasyonu\"]", "[\"ASP.NET Core\",\"Angular\",\"MS SQL\",\"Redis\",\"JavaScript/jQuery\"]" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TechStack",
                table: "Projects",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FeaturesJson", "TechStack", "TechnologiesJson" },
                values: new object[] { null, "ASP.NET Core MVC, Bootstrap 5, Entity Framework Core", null });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FeaturesJson", "TechStack", "TechnologiesJson" },
                values: new object[] { null, "React.js, .NET Core Web API, Entity Framework Core", null });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FeaturesJson", "TechStack", "TechnologiesJson" },
                values: new object[] { null, "ASP.NET Core, Angular, MS SQL, Redis", null });
        }
    }
}
