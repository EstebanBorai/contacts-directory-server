using Microsoft.EntityFrameworkCore.Migrations;

namespace ContactsDirectory.API.Migrations
{
    public partial class AddFavoriteContact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Favorite",
                table: "Contacts",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Favorite",
                table: "Contacts");
        }
    }
}
