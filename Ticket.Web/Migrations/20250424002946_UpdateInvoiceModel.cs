using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ticket.Web.Migrations
{
    /// <inheritdoc />
    public partial class UpdateInvoiceModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discount",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "IdPaymentCategory",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "Subtotal",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "Tax",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "Invoices");

            migrationBuilder.RenameColumn(
                name: "IdUser",
                table: "Invoices",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Invoices",
                newName: "PurchaseDate");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Invoices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EventName",
                table: "Invoices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Invoices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PaymentMethod",
                table: "Invoices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Seat",
                table: "Invoices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "EventName",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "PaymentMethod",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "Seat",
                table: "Invoices");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "Invoices",
                newName: "IdUser");

            migrationBuilder.RenameColumn(
                name: "PurchaseDate",
                table: "Invoices",
                newName: "Date");

            migrationBuilder.AddColumn<decimal>(
                name: "Discount",
                table: "Invoices",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "IdPaymentCategory",
                table: "Invoices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Subtotal",
                table: "Invoices",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Tax",
                table: "Invoices",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Total",
                table: "Invoices",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
