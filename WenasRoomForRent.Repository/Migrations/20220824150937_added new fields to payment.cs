using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WenasRoomForRent.Repository.Migrations
{
    public partial class addednewfieldstopayment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LastPrintDate",
                table: "Payments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PrintedTime",
                table: "Payments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastPrintDate",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "PrintedTime",
                table: "Payments");
        }
    }
}
