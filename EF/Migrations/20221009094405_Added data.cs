using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGTG_EF.Migrations
{
    public partial class Addeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentNumber", "BirthDate", "City", "EmailAddress", "Name", "Number", "Password", "PhoneNumber", "noShows" },
                values: new object[] { 12345, new DateTime(1998, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Breda", "rik@mail.com", "Rik Vandermullen", 12345, "secret", "0612345678", 0 });

            migrationBuilder.CreateIndex(
                name: "IX_Students_StudentNumber",
                table: "Students",
                column: "StudentNumber",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Students_StudentNumber",
                table: "Students");

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentNumber",
                keyValue: 12345);

            migrationBuilder.AlterColumn<int>(
                name: "City",
                table: "Students",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
