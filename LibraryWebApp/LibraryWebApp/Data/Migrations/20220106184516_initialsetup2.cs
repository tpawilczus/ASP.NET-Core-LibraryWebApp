using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryWebApp.Data.Migrations
{
    public partial class initialsetup2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_BookCategory_BookCategoryId",
                table: "Book");

            migrationBuilder.AlterColumn<int>(
                name: "BookCategoryId",
                table: "Book",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Book_BookCategory_BookCategoryId",
                table: "Book",
                column: "BookCategoryId",
                principalTable: "BookCategory",
                principalColumn: "BookCategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_BookCategory_BookCategoryId",
                table: "Book");

            migrationBuilder.AlterColumn<int>(
                name: "BookCategoryId",
                table: "Book",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_BookCategory_BookCategoryId",
                table: "Book",
                column: "BookCategoryId",
                principalTable: "BookCategory",
                principalColumn: "BookCategoryId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
