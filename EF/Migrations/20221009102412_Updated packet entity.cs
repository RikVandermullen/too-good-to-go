using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGTG_EF.Migrations
{
    public partial class Updatedpacketentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packets_Canteens_CanteenId",
                table: "Packets");

            migrationBuilder.DropForeignKey(
                name: "FK_Packets_Students_ReservedByStudentNumber",
                table: "Packets");

            migrationBuilder.DropIndex(
                name: "IX_Packets_CanteenId",
                table: "Packets");

            migrationBuilder.DropIndex(
                name: "IX_Packets_ReservedByStudentNumber",
                table: "Packets");

            migrationBuilder.DropColumn(
                name: "ReservedByStudentNumber",
                table: "Packets");

            migrationBuilder.RenameColumn(
                name: "CanteenId",
                table: "Packets",
                newName: "Canteen");

            migrationBuilder.AlterColumn<string>(
                name: "MealType",
                table: "Packets",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Packets",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "ReservedBy",
                table: "Packets",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReservedBy",
                table: "Packets");

            migrationBuilder.RenameColumn(
                name: "Canteen",
                table: "Packets",
                newName: "CanteenId");

            migrationBuilder.AlterColumn<int>(
                name: "MealType",
                table: "Packets",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "City",
                table: "Packets",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "ReservedByStudentNumber",
                table: "Packets",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Packets_CanteenId",
                table: "Packets",
                column: "CanteenId");

            migrationBuilder.CreateIndex(
                name: "IX_Packets_ReservedByStudentNumber",
                table: "Packets",
                column: "ReservedByStudentNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_Packets_Canteens_CanteenId",
                table: "Packets",
                column: "CanteenId",
                principalTable: "Canteens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Packets_Students_ReservedByStudentNumber",
                table: "Packets",
                column: "ReservedByStudentNumber",
                principalTable: "Students",
                principalColumn: "StudentNumber");
        }
    }
}
