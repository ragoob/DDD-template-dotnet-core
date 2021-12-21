using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace On.Infra.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,");

            migrationBuilder.CreateTable(
                name: "customer",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    Name = table.Column<string>(type: "text", nullable: true),
                    street = table.Column<string>(type: "text", nullable: true, defaultValue: ""),
                    city = table.Column<string>(type: "text", nullable: true, defaultValue: ""),
                    state = table.Column<string>(type: "text", nullable: true, defaultValue: ""),
                    country = table.Column<string>(type: "text", nullable: true, defaultValue: ""),
                    zip_code = table.Column<string>(type: "text", nullable: true, defaultValue: "")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerPhoto",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    CustomerId = table.Column<Guid>(type: "uuid", nullable: false),
                    path_url = table.Column<string>(type: "text", nullable: true),
                    alt = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerPhoto", x => new { x.CustomerId, x.id });
                    table.ForeignKey(
                        name: "FK_CustomerPhoto_customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "customer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerPhoto");

            migrationBuilder.DropTable(
                name: "customer");
        }
    }
}
