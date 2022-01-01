using Microsoft.EntityFrameworkCore.Migrations;

namespace CardFileOfTextMaterialsEpam.DAL.Migrations
{
    public partial class AddedConnection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EntityCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EntityUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EntityCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntityCards_EntityUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "EntityUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EntityBooks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CardId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityBooks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntityBooks_EntityCards_CardId",
                        column: x => x.CardId,
                        principalTable: "EntityCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EntityBooks_EntityCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "EntityCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EntityBooks_CardId",
                table: "EntityBooks",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityBooks_CategoryId",
                table: "EntityBooks",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityCards_UserId",
                table: "EntityCards",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EntityBooks");

            migrationBuilder.DropTable(
                name: "EntityCards");

            migrationBuilder.DropTable(
                name: "EntityCategories");

            migrationBuilder.DropTable(
                name: "EntityUsers");
        }
    }
}
