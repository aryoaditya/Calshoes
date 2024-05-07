using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_m_product_brands",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_product_brands", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_m_product_categories",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_product_categories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_m_products",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "TEXT", nullable: false),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    product_brand_id = table.Column<int>(type: "INTEGER", nullable: false),
                    product_category_id = table.Column<int>(type: "INTEGER", nullable: false),
                    created_date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    modified_date = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_products", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_m_products_tb_m_product_brands_product_brand_id",
                        column: x => x.product_brand_id,
                        principalTable: "tb_m_product_brands",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_m_products_tb_m_product_categories_product_category_id",
                        column: x => x.product_category_id,
                        principalTable: "tb_m_product_categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_m_product_images",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    image_url = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    product_id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_product_images", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_m_product_images_tb_m_products_product_id",
                        column: x => x.product_id,
                        principalTable: "tb_m_products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_m_product_variants",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    size = table.Column<decimal>(type: "decimal(2,2)", nullable: false),
                    color = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    stock_quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    product_id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_product_variants", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_m_product_variants_tb_m_products_product_id",
                        column: x => x.product_id,
                        principalTable: "tb_m_products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_product_brands_id",
                table: "tb_m_product_brands",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_product_categories_id",
                table: "tb_m_product_categories",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_product_images_id",
                table: "tb_m_product_images",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_product_images_product_id",
                table: "tb_m_product_images",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_product_variants_id",
                table: "tb_m_product_variants",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_product_variants_product_id",
                table: "tb_m_product_variants",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_products_id",
                table: "tb_m_products",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_products_product_brand_id",
                table: "tb_m_products",
                column: "product_brand_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_products_product_category_id",
                table: "tb_m_products",
                column: "product_category_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_m_product_images");

            migrationBuilder.DropTable(
                name: "tb_m_product_variants");

            migrationBuilder.DropTable(
                name: "tb_m_products");

            migrationBuilder.DropTable(
                name: "tb_m_product_brands");

            migrationBuilder.DropTable(
                name: "tb_m_product_categories");
        }
    }
}
