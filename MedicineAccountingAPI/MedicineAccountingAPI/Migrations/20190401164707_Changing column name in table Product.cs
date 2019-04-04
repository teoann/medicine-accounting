using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MedicineAccountingAPI.Migrations
{
    public partial class ChangingcolumnnameintableProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Amount = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Amount", "Name", "Price" },
                values: new object[] { 1, 20, "Citramon", 10.0 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Amount", "Name", "Price" },
                values: new object[] { 2, 50, "Nimessil", 11.5 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Amount", "Name", "Price" },
                values: new object[] { 3, 20, "Nurofen", 50.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
