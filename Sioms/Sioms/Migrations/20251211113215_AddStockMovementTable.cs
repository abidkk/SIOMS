using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sioms.Migrations
{
    /// <inheritdoc />
    public partial class AddStockMovementTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Reason",
                table: "StockMovements");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "StockMovements",
                newName: "QuantityChanged");

            migrationBuilder.RenameColumn(
                name: "OccurredAt",
                table: "StockMovements",
                newName: "MovementDate");

            migrationBuilder.AddColumn<int>(
                name: "FinalStock",
                table: "StockMovements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ReferenceNumber",
                table: "StockMovements",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FinalStock",
                table: "StockMovements");

            migrationBuilder.DropColumn(
                name: "ReferenceNumber",
                table: "StockMovements");

            migrationBuilder.RenameColumn(
                name: "QuantityChanged",
                table: "StockMovements",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "MovementDate",
                table: "StockMovements",
                newName: "OccurredAt");

            migrationBuilder.AddColumn<string>(
                name: "Reason",
                table: "StockMovements",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
