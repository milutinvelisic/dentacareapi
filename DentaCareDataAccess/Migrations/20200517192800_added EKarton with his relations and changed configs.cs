using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DentaCareDataAccess.Migrations
{
    public partial class addedEKartonwithhisrelationsandchangedconfigs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EKarton",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    ServiceTypeId = table.Column<int>(nullable: false),
                    JawJawSideToothId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EKarton", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EKarton_JawJawSideTeeth_JawJawSideToothId",
                        column: x => x.JawJawSideToothId,
                        principalTable: "JawJawSideTeeth",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EKarton_ServiceTypes_ServiceTypeId",
                        column: x => x.ServiceTypeId,
                        principalTable: "ServiceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EKarton_JawJawSideToothId",
                table: "EKarton",
                column: "JawJawSideToothId");

            migrationBuilder.CreateIndex(
                name: "IX_EKarton_ServiceTypeId",
                table: "EKarton",
                column: "ServiceTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EKarton");
        }
    }
}
