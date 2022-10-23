using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGTG_EF.Migrations
{
    public partial class Updateddatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PacketProduct",
                columns: table => new
                {
                    PacketsId = table.Column<int>(type: "int", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PacketProduct", x => new { x.PacketsId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_PacketProduct_Packets_PacketsId",
                        column: x => x.PacketsId,
                        principalTable: "Packets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PacketProduct_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PacketProduct_ProductsId",
                table: "PacketProduct",
                column: "ProductsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PacketProduct");
        }
    }
}
