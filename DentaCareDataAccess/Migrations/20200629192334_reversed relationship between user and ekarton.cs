using Microsoft.EntityFrameworkCore.Migrations;

namespace DentaCareDataAccess.Migrations
{
    public partial class reversedrelationshipbetweenuserandekarton : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "EKarton",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_EKarton_UserId",
                table: "EKarton",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EKarton_Users_UserId",
                table: "EKarton",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EKarton_Users_UserId",
                table: "EKarton");

            migrationBuilder.DropIndex(
                name: "IX_EKarton_UserId",
                table: "EKarton");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "EKarton");

            migrationBuilder.AddColumn<int>(
                name: "EKartonId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_EKartonId",
                table: "Users",
                column: "EKartonId",
                unique: true,
                filter: "[EKartonId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_EKarton_EKartonId",
                table: "Users",
                column: "EKartonId",
                principalTable: "EKarton",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
