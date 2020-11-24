using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class addedPRopertyToProSpecification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CPU",
                table: "ProductSpecification",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CPUrecommended",
                table: "ProductSpecification",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GPU",
                table: "ProductSpecification",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Memory",
                table: "ProductSpecification",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Memoryrecommended",
                table: "ProductSpecification",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OS",
                table: "ProductSpecification",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CPU",
                table: "ProductSpecification");

            migrationBuilder.DropColumn(
                name: "CPUrecommended",
                table: "ProductSpecification");

            migrationBuilder.DropColumn(
                name: "GPU",
                table: "ProductSpecification");

            migrationBuilder.DropColumn(
                name: "Memory",
                table: "ProductSpecification");

            migrationBuilder.DropColumn(
                name: "Memoryrecommended",
                table: "ProductSpecification");

            migrationBuilder.DropColumn(
                name: "OS",
                table: "ProductSpecification");
        }
    }
}
