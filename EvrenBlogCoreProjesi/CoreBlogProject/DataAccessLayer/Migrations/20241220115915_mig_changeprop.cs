using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class mig_changeprop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_AspNetUsers_appUserId",
                table: "Blogs");

            migrationBuilder.DropIndex(
                name: "IX_Blogs_appUserId",
                table: "Blogs");

            migrationBuilder.RenameColumn(
                name: "appUserId",
                table: "Blogs",
                newName: "AppUserId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Blogs",
                newName: "AppUserId1");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_AppUserId1",
                table: "Blogs",
                column: "AppUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_AspNetUsers_AppUserId1",
                table: "Blogs",
                column: "AppUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_AspNetUsers_AppUserId1",
                table: "Blogs");

            migrationBuilder.DropIndex(
                name: "IX_Blogs_AppUserId1",
                table: "Blogs");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "Blogs",
                newName: "appUserId");

            migrationBuilder.RenameColumn(
                name: "AppUserId1",
                table: "Blogs",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "appUserId",
                table: "Blogs",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_appUserId",
                table: "Blogs",
                column: "appUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_AspNetUsers_appUserId",
                table: "Blogs",
                column: "appUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
