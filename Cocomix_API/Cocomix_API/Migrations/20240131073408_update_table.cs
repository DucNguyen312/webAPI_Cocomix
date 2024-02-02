using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cocomix_API.Migrations
{
    public partial class update_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    categoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category", x => x.categoryID);
                });

            migrationBuilder.CreateTable(
                name: "customer",
                columns: table => new
                {
                    customerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    phoneNumber = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer", x => x.customerID);
                });

            migrationBuilder.CreateTable(
                name: "product",
                columns: table => new
                {
                    productID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    price = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    quantity = table.Column<int>(type: "int", nullable: true),
                    note = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product", x => x.productID);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    userID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fullName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    birthday = table.Column<DateTime>(type: "date", nullable: true),
                    phoneNumber = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    email = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.userID);
                });

            migrationBuilder.CreateTable(
                name: "product_category",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productID = table.Column<int>(type: "int", nullable: true),
                    categoryID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_category", x => x.id);
                    table.ForeignKey(
                        name: "FK__product_c__categ__70DDC3D8",
                        column: x => x.categoryID,
                        principalTable: "category",
                        principalColumn: "categoryID");
                    table.ForeignKey(
                        name: "FK__product_c__produ__6FE99F9F",
                        column: x => x.productID,
                        principalTable: "product",
                        principalColumn: "productID");
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    orderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    note = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    status = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    totalPrice = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    totalProduct = table.Column<int>(type: "int", nullable: true),
                    orderDate = table.Column<DateTime>(type: "date", nullable: true),
                    userID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.orderID);
                    table.ForeignKey(
                        name: "FK__orders__userID__4316F928",
                        column: x => x.userID,
                        principalTable: "users",
                        principalColumn: "userID");
                });

            migrationBuilder.CreateTable(
                name: "customer_order",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customerID = table.Column<int>(type: "int", nullable: true),
                    orderID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer_order", x => x.id);
                    table.ForeignKey(
                        name: "FK__customer___custo__45F365D3",
                        column: x => x.customerID,
                        principalTable: "customer",
                        principalColumn: "customerID");
                    table.ForeignKey(
                        name: "FK__customer___order__46E78A0C",
                        column: x => x.orderID,
                        principalTable: "orders",
                        principalColumn: "orderID");
                });

            migrationBuilder.CreateTable(
                name: "orderDetails",
                columns: table => new
                {
                    orderDetailID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    totalPrice = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    productID = table.Column<int>(type: "int", nullable: true),
                    orderID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderDetails", x => x.orderDetailID);
                    table.ForeignKey(
                        name: "FK__orderDeta__order__4AB81AF0",
                        column: x => x.orderID,
                        principalTable: "orders",
                        principalColumn: "orderID");
                    table.ForeignKey(
                        name: "FK__orderDeta__produ__49C3F6B7",
                        column: x => x.productID,
                        principalTable: "product",
                        principalColumn: "productID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_customer_order_customerID",
                table: "customer_order",
                column: "customerID");

            migrationBuilder.CreateIndex(
                name: "IX_customer_order_orderID",
                table: "customer_order",
                column: "orderID");

            migrationBuilder.CreateIndex(
                name: "IX_orderDetails_orderID",
                table: "orderDetails",
                column: "orderID");

            migrationBuilder.CreateIndex(
                name: "IX_orderDetails_productID",
                table: "orderDetails",
                column: "productID");

            migrationBuilder.CreateIndex(
                name: "IX_orders_userID",
                table: "orders",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_product_category_categoryID",
                table: "product_category",
                column: "categoryID");

            migrationBuilder.CreateIndex(
                name: "IX_product_category_productID",
                table: "product_category",
                column: "productID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "customer_order");

            migrationBuilder.DropTable(
                name: "orderDetails");

            migrationBuilder.DropTable(
                name: "product_category");

            migrationBuilder.DropTable(
                name: "customer");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "category");

            migrationBuilder.DropTable(
                name: "product");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
