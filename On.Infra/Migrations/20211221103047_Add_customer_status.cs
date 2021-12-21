using Microsoft.EntityFrameworkCore.Migrations;

namespace On.Infra.Migrations
{
    public partial class Add_customer_status : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerStatus",
                table: "customer",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerStatus",
                table: "customer");
        }
    }
}
