using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WenasRoomForRent.Repository.Migrations
{
    public partial class addedprofileremarks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Remarks",
                table: "Profiles",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Remarks",
                table: "Profiles");
        }
    }
}
