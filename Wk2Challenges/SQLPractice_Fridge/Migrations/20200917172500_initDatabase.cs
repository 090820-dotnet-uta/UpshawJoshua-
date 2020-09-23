using Microsoft.EntityFrameworkCore.Migrations;

namespace SQLPractice_Fridge.Migrations
{
    public partial class initDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fridge",
                columns: table => new
                {
                    shelfID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    itemType = table.Column<string>(nullable: true),
                    shelfCapacity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fridge", x => x.shelfID);
                });

            migrationBuilder.CreateTable(
                name: "FridgeItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    itemCount = table.Column<int>(nullable: false),
                    itemType = table.Column<string>(nullable: true),
                    itemName = table.Column<string>(nullable: true),
                    FridgeshelfID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FridgeItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FridgeItem_Fridge_FridgeshelfID",
                        column: x => x.FridgeshelfID,
                        principalTable: "Fridge",
                        principalColumn: "shelfID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FridgeItem_FridgeshelfID",
                table: "FridgeItem",
                column: "FridgeshelfID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FridgeItem");

            migrationBuilder.DropTable(
                name: "Fridge");
        }
    }
}
