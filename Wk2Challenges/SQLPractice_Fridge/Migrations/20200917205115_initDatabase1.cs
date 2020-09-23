using Microsoft.EntityFrameworkCore.Migrations;

namespace SQLPractice_Fridge.Migrations
{
    public partial class initDatabase1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FridgeItem_Fridge_FridgeshelfID",
                table: "FridgeItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FridgeItem",
                table: "FridgeItem");

            migrationBuilder.DropIndex(
                name: "IX_FridgeItem_FridgeshelfID",
                table: "FridgeItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Fridge",
                table: "Fridge");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "FridgeItem");

            migrationBuilder.DropColumn(
                name: "FridgeshelfID",
                table: "FridgeItem");

            migrationBuilder.DropColumn(
                name: "shelfID",
                table: "Fridge");

            migrationBuilder.DropColumn(
                name: "itemType",
                table: "Fridge");

            migrationBuilder.RenameTable(
                name: "Fridge",
                newName: "FridgeShelf");

            migrationBuilder.AddColumn<int>(
                name: "FridgeItemId",
                table: "FridgeItem",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "FridgeId",
                table: "FridgeShelf",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "shelfType",
                table: "FridgeShelf",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_FridgeItem",
                table: "FridgeItem",
                column: "FridgeItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FridgeShelf",
                table: "FridgeShelf",
                column: "FridgeId");

            migrationBuilder.CreateTable(
                name: "Shelf",
                columns: table => new
                {
                    FridgeShelfId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FridgeItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shelf", x => x.FridgeShelfId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Shelf");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FridgeItem",
                table: "FridgeItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FridgeShelf",
                table: "FridgeShelf");

            migrationBuilder.DropColumn(
                name: "FridgeItemId",
                table: "FridgeItem");

            migrationBuilder.DropColumn(
                name: "FridgeId",
                table: "FridgeShelf");

            migrationBuilder.DropColumn(
                name: "shelfType",
                table: "FridgeShelf");

            migrationBuilder.RenameTable(
                name: "FridgeShelf",
                newName: "Fridge");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "FridgeItem",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "FridgeshelfID",
                table: "FridgeItem",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "shelfID",
                table: "Fridge",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "itemType",
                table: "Fridge",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_FridgeItem",
                table: "FridgeItem",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fridge",
                table: "Fridge",
                column: "shelfID");

            migrationBuilder.CreateIndex(
                name: "IX_FridgeItem_FridgeshelfID",
                table: "FridgeItem",
                column: "FridgeshelfID");

            migrationBuilder.AddForeignKey(
                name: "FK_FridgeItem_Fridge_FridgeshelfID",
                table: "FridgeItem",
                column: "FridgeshelfID",
                principalTable: "Fridge",
                principalColumn: "shelfID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
