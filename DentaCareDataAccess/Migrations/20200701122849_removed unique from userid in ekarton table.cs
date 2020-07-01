using Microsoft.EntityFrameworkCore.Migrations;

namespace DentaCareDataAccess.Migrations
{
    public partial class removeduniquefromuseridinekartontable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_EKarton_UserId",
                table: "EKarton");

            migrationBuilder.CreateIndex(
                name: "IX_EKarton_UserId",
                table: "EKarton",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_EKarton_UserId",
                table: "EKarton");

            migrationBuilder.CreateIndex(
                name: "IX_EKarton_UserId",
                table: "EKarton",
                column: "UserId",
                unique: true);
        }
    }
}
