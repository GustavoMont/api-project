using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_project.Migrations
{
    public partial class AddPasswordToFirm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Firms",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Firms_Cnpj",
                table: "Firms",
                column: "Cnpj",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Firms_Email",
                table: "Firms",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Firms_Cnpj",
                table: "Firms");

            migrationBuilder.DropIndex(
                name: "IX_Firms_Email",
                table: "Firms");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Firms");
        }
    }
}
