using Microsoft.EntityFrameworkCore.Migrations;

namespace LocadoraWebAPI.Migrations.VideoStoreDb
{
    public partial class MyMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DashboardMovie",
                columns: table => new
                {
                    DashBoardMoviesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StockMoviesCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DashboardMovie", x => x.DashBoardMoviesId);
                });

            migrationBuilder.CreateTable(
                name: "MovieCategory",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieCategory", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "VideoStoreItens",
                columns: table => new
                {
                    VideoStoreID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuantityStock = table.Column<int>(type: "int", nullable: false),
                    NumberRegister = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    DashBoardMoviesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoStoreItens", x => x.VideoStoreID);
                    table.ForeignKey(
                        name: "FK_VideoStoreItens_DashboardMovie_DashBoardMoviesId",
                        column: x => x.DashBoardMoviesId,
                        principalTable: "DashboardMovie",
                        principalColumn: "DashBoardMoviesId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VideoStoreItens_MovieCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "MovieCategory",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VideoStoreItens_CategoryId",
                table: "VideoStoreItens",
                column: "CategoryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VideoStoreItens_DashBoardMoviesId",
                table: "VideoStoreItens",
                column: "DashBoardMoviesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VideoStoreItens");

            migrationBuilder.DropTable(
                name: "DashboardMovie");

            migrationBuilder.DropTable(
                name: "MovieCategory");
        }
    }
}
