using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VaquerSansPere.Backend.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class OrederedListTableFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Height",
                schema: "PVS-BBDD",
                table: "order_list_data",
                newName: "OrderedList");

            migrationBuilder.RenameColumn(
                name: "Base",
                schema: "PVS-BBDD",
                table: "order_list_data",
                newName: "OriginalList");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OriginalList",
                schema: "PVS-BBDD",
                table: "order_list_data",
                newName: "Base");

            migrationBuilder.RenameColumn(
                name: "OrderedList",
                schema: "PVS-BBDD",
                table: "order_list_data",
                newName: "Height");
        }
    }
}
