using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGTG_EF.Migrations
{
    public partial class UpdatedPacket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Packets_PacketId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_PacketId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PacketId",
                table: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PacketId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_PacketId",
                table: "Products",
                column: "PacketId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Packets_PacketId",
                table: "Products",
                column: "PacketId",
                principalTable: "Packets",
                principalColumn: "Id");
        }
    }
}
