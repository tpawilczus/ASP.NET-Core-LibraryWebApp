using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryWebApp.Data.Migrations
{
    public partial class initialsetup1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "BookCategory",
                newName: "BookCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BookCategoryId",
                table: "BookCategory",
                newName: "Id");
        }
    }
}
