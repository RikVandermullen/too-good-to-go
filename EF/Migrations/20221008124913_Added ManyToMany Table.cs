using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGTG_EF.Migrations
{
    public partial class AddedManyToManyTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packets_Products_ProductName",
                table: "Packets");

            migrationBuilder.DropIndex(
                name: "IX_Packets_ProductName",
                table: "Packets");

            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "Packets");

            migrationBuilder.AddColumn<bool>(
                name: "HasAlcohol",
                table: "Packets",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "PacketProduct",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PacketId = table.Column<int>(type: "int", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PacketProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PacketProduct_Packets_PacketId",
                        column: x => x.PacketId,
                        principalTable: "Packets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PacketProduct_Products_ProductName",
                        column: x => x.ProductName,
                        principalTable: "Products",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PacketProduct_PacketId",
                table: "PacketProduct",
                column: "PacketId");

            migrationBuilder.CreateIndex(
                name: "IX_PacketProduct_ProductName",
                table: "PacketProduct",
                column: "ProductName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PacketProduct");

            migrationBuilder.DropColumn(
                name: "HasAlcohol",
                table: "Packets");

            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "Packets",
                type: "nvarchar(50)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Packets_ProductName",
                table: "Packets",
                column: "ProductName");

            migrationBuilder.AddForeignKey(
                name: "FK_Packets_Products_ProductName",
                table: "Packets",
                column: "ProductName",
                principalTable: "Products",
                principalColumn: "Name");
        }
    }
}
