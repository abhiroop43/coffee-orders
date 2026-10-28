using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoffeeOrders.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Coffees_CoffeeId",
                schema: "CoffeeOrders",
                table: "Orders");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Coffees_CoffeeId",
                schema: "CoffeeOrders",
                table: "Orders",
                column: "CoffeeId",
                principalSchema: "CoffeeOrders",
                principalTable: "Coffees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Coffees_CoffeeId",
                schema: "CoffeeOrders",
                table: "Orders");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Coffees_CoffeeId",
                schema: "CoffeeOrders",
                table: "Orders",
                column: "CoffeeId",
                principalSchema: "CoffeeOrders",
                principalTable: "Coffees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
