using Microsoft.EntityFrameworkCore.Migrations;

namespace Swaad.Data.Migrations
{
    public partial class populated_tables_new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "FoodItems",
                columns: table => new
                {
                    FoodId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FoodName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FoodDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageThumbnailUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    IsTodaySpecial = table.Column<bool>(type: "bit", nullable: false),
                    HasDiscount = table.Column<bool>(type: "bit", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodItems", x => x.FoodId);
                    table.ForeignKey(
                        name: "FK_FoodItems_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName", "Description" },
                values: new object[] { 1, "Veg", "Pure Veg" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName", "Description" },
                values: new object[] { 2, "Veg + Egg", "Veg and Egg" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName", "Description" },
                values: new object[] { 3, "NonVeg", "NonVeg" });

            migrationBuilder.InsertData(
                table: "FoodItems",
                columns: new[] { "FoodId", "CategoryId", "FoodDescription", "FoodName", "HasDiscount", "ImageThumbnailUrl", "ImageUrl", "IsAvailable", "IsTodaySpecial", "Price" },
                values: new object[] { 1, 1, "Mumbai Special", "Vadapav", false, "/Images/vadapav.png", "/Images/vadapav.png", true, true, 20m });

            migrationBuilder.InsertData(
                table: "FoodItems",
                columns: new[] { "FoodId", "CategoryId", "FoodDescription", "FoodName", "HasDiscount", "ImageThumbnailUrl", "ImageUrl", "IsAvailable", "IsTodaySpecial", "Price" },
                values: new object[] { 2, 2, "Egg Special", "Egg Omlet", false, "/Images/omlet.png", "/Images/omlet.png", true, true, 25m });

            migrationBuilder.InsertData(
                table: "FoodItems",
                columns: new[] { "FoodId", "CategoryId", "FoodDescription", "FoodName", "HasDiscount", "ImageThumbnailUrl", "ImageUrl", "IsAvailable", "IsTodaySpecial", "Price" },
                values: new object[] { 3, 3, "Chicken Special", "Chicken Biryani", false, "/Images/biryani.png", "/Images/biryani.png", true, true, 200m });

            migrationBuilder.CreateIndex(
                name: "IX_FoodItems_CategoryId",
                table: "FoodItems",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FoodItems");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
