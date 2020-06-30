using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DentaCareDataAccess.Migrations
{
    public partial class addedclassesforjawjawsideteethandrelationaltableforthose3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jaws",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    JawName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jaws", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JawSides",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    JawSideName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JawSides", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teeth",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    ToothNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teeth", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JawJawSideTeeth",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    JawId = table.Column<int>(nullable: false),
                    JawSideId = table.Column<int>(nullable: false),
                    ToothId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JawJawSideTeeth", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JawJawSideTeeth_Jaws_JawId",
                        column: x => x.JawId,
                        principalTable: "Jaws",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JawJawSideTeeth_JawSides_JawSideId",
                        column: x => x.JawSideId,
                        principalTable: "JawSides",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JawJawSideTeeth_Teeth_ToothId",
                        column: x => x.ToothId,
                        principalTable: "Teeth",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JawJawSideTeeth_JawId",
                table: "JawJawSideTeeth",
                column: "JawId");

            migrationBuilder.CreateIndex(
                name: "IX_JawJawSideTeeth_JawSideId",
                table: "JawJawSideTeeth",
                column: "JawSideId");

            migrationBuilder.CreateIndex(
                name: "IX_JawJawSideTeeth_ToothId",
                table: "JawJawSideTeeth",
                column: "ToothId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JawJawSideTeeth");

            migrationBuilder.DropTable(
                name: "Jaws");

            migrationBuilder.DropTable(
                name: "JawSides");

            migrationBuilder.DropTable(
                name: "Teeth");
        }
    }
}
