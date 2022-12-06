using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_project.Migrations
{
    public partial class UpdateServiceModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_ServiceTypes_ServiceTypeId",
                table: "Services"
            );

            migrationBuilder.DropColumn(name: "CompletionDeadline", table: "Services");

            migrationBuilder.DropColumn(name: "ContractId", table: "Services");

            migrationBuilder.DropColumn(name: "StartDate", table: "Services");

            migrationBuilder.AlterColumn<int>(
                name: "ServiceTypeId",
                table: "Services",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true
            );

            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "Services",
                type: "int(4)",
                nullable: false,
                defaultValue: 0
            );

            migrationBuilder.AddForeignKey(
                name: "FK_Services_ServiceTypes_ServiceTypeId",
                table: "Services",
                column: "ServiceTypeId",
                principalTable: "ServiceTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_ServiceTypes_ServiceTypeId",
                table: "Services"
            );

            migrationBuilder.DropColumn(name: "Duration", table: "Services");

            migrationBuilder.AlterColumn<int>(
                name: "ServiceTypeId",
                table: "Services",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int"
            );

            migrationBuilder.AddColumn<DateTime>(
                name: "CompletionDeadline",
                table: "Services",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
            );

            migrationBuilder.AddColumn<int>(
                name: "ContractId",
                table: "Services",
                type: "int",
                nullable: false,
                defaultValue: 0
            );

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Services",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
            );

            migrationBuilder.AddForeignKey(
                name: "FK_Services_ServiceTypes_ServiceTypeId",
                table: "Services",
                column: "ServiceTypeId",
                principalTable: "ServiceTypes",
                principalColumn: "Id"
            );
        }
    }
}
