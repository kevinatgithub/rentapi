using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WenasRoomForRent.Repository.Migrations
{
    public partial class paymentforroom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "PaymentForRoom",
                table: "Payments",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentForRoom",
                table: "Payments");
        }
    }
}
