using Microsoft.EntityFrameworkCore.Migrations;

namespace DentaCareDataAccess.Migrations
{
    public partial class changedrelationbetweenuserandekarton : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EKartonId",
                table: "Users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Users_EKartonId",
                table: "Users",
                column: "EKartonId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_EKarton_EKartonId",
                table: "Users",
                column: "EKartonId",
                principalTable: "EKarton",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_EKarton_EKartonId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_EKartonId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "EKartonId",
                table: "Users");
        }
    }
}
