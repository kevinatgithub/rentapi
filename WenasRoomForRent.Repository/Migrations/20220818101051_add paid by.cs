using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WenasRoomForRent.Repository.Migrations
{
    public partial class addpaidby : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PaidBy",
                table: "Payments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaidBy",
                table: "Payments");
        }
    }
}
