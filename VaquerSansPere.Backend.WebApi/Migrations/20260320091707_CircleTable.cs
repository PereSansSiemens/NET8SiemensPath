using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace VaquerSansPere.Backend.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class CircleTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                schema: "PVS-BBDD",
                table: "order_list_data",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "circle_data",
                schema: "PVS-BBDD",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Radius = table.Column<double>(type: "double precision", nullable: false),
                    Color = table.Column<string>(type: "text", nullable: false),
                    Perimeter = table.Column<double>(type: "double precision", nullable: false),
                    Area = table.Column<double>(type: "double precision", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_circle_data", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "circle_data",
                schema: "PVS-BBDD");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                schema: "PVS-BBDD",
                table: "order_list_data");
        }
    }
}
