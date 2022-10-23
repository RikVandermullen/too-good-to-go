using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGTG_EF.Migrations
{
    public partial class Updatedmodelbuilder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PacketProduct_Packets_PacketsId",
                table: "PacketProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_PacketProduct_Products_ProductsId",
                table: "PacketProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PacketProduct",
                table: "PacketProduct");

            migrationBuilder.RenameColumn(
                name: "ProductsId",
                table: "PacketProduct",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "PacketsId",
                table: "PacketProduct",
                newName: "PacketId");

            migrationBuilder.RenameIndex(
                name: "IX_PacketProduct_ProductsId",
                table: "PacketProduct",
                newName: "IX_PacketProduct_ProductId");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "PacketProduct",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PacketProduct",
                table: "PacketProduct",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PacketProduct_PacketId",
                table: "PacketProduct",
                column: "PacketId");

            migrationBuilder.AddForeignKey(
                name: "FK_PacketProduct_Packets_PacketId",
                table: "PacketProduct",
                column: "PacketId",
                principalTable: "Packets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PacketProduct_Products_ProductId",
                table: "PacketProduct",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PacketProduct_Packets_PacketId",
                table: "PacketProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_PacketProduct_Products_ProductId",
                table: "PacketProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PacketProduct",
                table: "PacketProduct");

            migrationBuilder.DropIndex(
                name: "IX_PacketProduct_PacketId",
                table: "PacketProduct");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "PacketProduct");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "PacketProduct",
                newName: "ProductsId");

            migrationBuilder.RenameColumn(
                name: "PacketId",
                table: "PacketProduct",
                newName: "PacketsId");

            migrationBuilder.RenameIndex(
                name: "IX_PacketProduct_ProductId",
                table: "PacketProduct",
                newName: "IX_PacketProduct_ProductsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PacketProduct",
                table: "PacketProduct",
                columns: new[] { "PacketsId", "ProductsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PacketProduct_Packets_PacketsId",
                table: "PacketProduct",
                column: "PacketsId",
                principalTable: "Packets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PacketProduct_Products_ProductsId",
                table: "PacketProduct",
                column: "ProductsId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
