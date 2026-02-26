using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStoreAspire.ApiService.Migrations
{
    public partial class SeedInitialBooks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: ["Id", "Title", "Author", "Price"],
                values: new object[,]
                {
                    {
                        new Guid("11111111-1111-1111-1111-111111111111"),
                        "Clean Code",
                        "Robert C. Martin",
                        39.99m
                    },
                    {
                        new Guid("22222222-2222-2222-2222-222222222222"),
                        "The Pragmatic Programmer",
                        "Andrew Hunt and David Thomas",
                        44.90m
                    },
                    {
                        new Guid("33333333-3333-3333-3333-333333333333"),
                        "Domain-Driven Design",
                        "Eric Evans",
                        59.00m
                    },
                    {
                        new Guid("44444444-4444-4444-4444-444444444444"),
                        "Refactoring",
                        "Martin Fowler",
                        49.50m
                    },
                    {
                        new Guid("55555555-5555-5555-5555-555555555555"),
                        "Design Patterns",
                        "Erich Gamma, Richard Helm, Ralph Johnson, John Vlissides",
                        54.75m
                    }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValues:
                [
                    new Guid("11111111-1111-1111-1111-111111111111"),
                    new Guid("22222222-2222-2222-2222-222222222222"),
                    new Guid("33333333-3333-3333-3333-333333333333"),
                    new Guid("44444444-4444-4444-4444-444444444444"),
                    new Guid("55555555-5555-5555-5555-555555555555")
                ]);
        }
    }
}
