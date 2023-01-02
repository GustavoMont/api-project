using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_project.Migrations
{
    public partial class AddFIrmIdContract : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FirmId",
                table: "Contracts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_FirmId",
                table: "Contracts",
                column: "FirmId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Firms_FirmId",
                table: "Contracts",
                column: "FirmId",
                principalTable: "Firms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Firms_FirmId",
                table: "Contracts");

            migrationBuilder.DropIndex(
                name: "IX_Contracts_FirmId",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "FirmId",
                table: "Contracts");
        }
    }
}
