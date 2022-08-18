using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WenasRoomForRent.Repository.Migrations
{
    public partial class addedparticularscolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Particulars",
                table: "Payments",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Particulars",
                table: "Payments");
        }
    }
}
