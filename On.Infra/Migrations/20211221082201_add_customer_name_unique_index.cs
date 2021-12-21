using Microsoft.EntityFrameworkCore.Migrations;

namespace On.Infra.Migrations
{
    public partial class add_customer_name_unique_index : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_customer_Name",
                table: "customer",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_customer_Name",
                table: "customer");
        }
    }
}
