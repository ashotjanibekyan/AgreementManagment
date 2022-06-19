using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgreementManagment.Migrations
{
    public partial class addSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "Active", "Code", "Description" },
                values: new object[,]
                {
                    { 1, true, "this is group code #1", "this is group description #1" },
                    { 2, false, "this is group code #2", "this is group description #2" },
                    { 3, false, "this is group code #3", "this is group description #3" },
                    { 4, false, "this is group code #4", "this is group description #4" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Active", "Description", "Number", "Price" },
                values: new object[,]
                {
                    { 1, true, "This is product description #1", 42, 42m },
                    { 2, true, "This is product description #2", 43, 423m },
                    { 3, true, "This is product description #4", 4233, 4123m },
                    { 4, true, "This is product description #5", 4983, 4223m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
