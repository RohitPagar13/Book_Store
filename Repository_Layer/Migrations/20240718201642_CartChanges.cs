using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository_Layer.Migrations
{
    public partial class CartChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsInStock",
                table: "Carts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "AdminEntityAdminId",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AdminId",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Books_AdminEntityAdminId",
                table: "Books",
                column: "AdminEntityAdminId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Admins_AdminEntityAdminId",
                table: "Books",
                column: "AdminEntityAdminId",
                principalTable: "Admins",
                principalColumn: "AdminId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Admins_AdminEntityAdminId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_AdminEntityAdminId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "IsInStock",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "AdminEntityAdminId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "Books");
        }
    }
}
