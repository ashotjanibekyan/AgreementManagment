using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgreementManagment.Migrations
{
    public partial class addIsActiveToAgreement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agreement_AspNetUsers_UserId",
                table: "Agreement");

            migrationBuilder.DropIndex(
                name: "IX_Agreement_UserId",
                table: "Agreement");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Agreement",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Agreement",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Agreement");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Agreement",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Agreement_UserId",
                table: "Agreement",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agreement_AspNetUsers_UserId",
                table: "Agreement",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
