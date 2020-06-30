using Microsoft.EntityFrameworkCore.Migrations;

namespace DentaCareDataAccess.Migrations
{
    public partial class changedekartonidfromuniquetononunique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_EKartonId",
                table: "Users");

            migrationBuilder.CreateIndex(
                name: "IX_Users_EKartonId",
                table: "Users",
                column: "EKartonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_EKartonId",
                table: "Users");

            migrationBuilder.CreateIndex(
                name: "IX_Users_EKartonId",
                table: "Users",
                column: "EKartonId",
                unique: true);
        }
    }
}
