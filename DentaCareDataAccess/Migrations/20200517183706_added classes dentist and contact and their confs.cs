using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DentaCareDataAccess.Migrations
{
    public partial class addedclassesdentistandcontactandtheirconfs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JawJawSideTeeth_Jaws_JawId",
                table: "JawJawSideTeeth");

            migrationBuilder.DropForeignKey(
                name: "FK_JawJawSideTeeth_JawSides_JawSideId",
                table: "JawJawSideTeeth");

            migrationBuilder.DropForeignKey(
                name: "FK_JawJawSideTeeth_Teeth_ToothId",
                table: "JawJawSideTeeth");

            migrationBuilder.AlterColumn<string>(
                name: "JawSideName",
                table: "JawSides",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "JawName",
                table: "Jaws",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    Fax = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dentists",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 30, nullable: false),
                    LastName = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dentists", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Teeth_ToothNumber",
                table: "Teeth",
                column: "ToothNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_JawSides_JawSideName",
                table: "JawSides",
                column: "JawSideName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Jaws_JawName",
                table: "Jaws",
                column: "JawName",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_JawJawSideTeeth_Jaws_JawId",
                table: "JawJawSideTeeth",
                column: "JawId",
                principalTable: "Jaws",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JawJawSideTeeth_JawSides_JawSideId",
                table: "JawJawSideTeeth",
                column: "JawSideId",
                principalTable: "JawSides",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JawJawSideTeeth_Teeth_ToothId",
                table: "JawJawSideTeeth",
                column: "ToothId",
                principalTable: "Teeth",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JawJawSideTeeth_Jaws_JawId",
                table: "JawJawSideTeeth");

            migrationBuilder.DropForeignKey(
                name: "FK_JawJawSideTeeth_JawSides_JawSideId",
                table: "JawJawSideTeeth");

            migrationBuilder.DropForeignKey(
                name: "FK_JawJawSideTeeth_Teeth_ToothId",
                table: "JawJawSideTeeth");

            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.DropTable(
                name: "Dentists");

            migrationBuilder.DropIndex(
                name: "IX_Teeth_ToothNumber",
                table: "Teeth");

            migrationBuilder.DropIndex(
                name: "IX_JawSides_JawSideName",
                table: "JawSides");

            migrationBuilder.DropIndex(
                name: "IX_Jaws_JawName",
                table: "Jaws");

            migrationBuilder.AlterColumn<string>(
                name: "JawSideName",
                table: "JawSides",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "JawName",
                table: "Jaws",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 10);

            migrationBuilder.AddForeignKey(
                name: "FK_JawJawSideTeeth_Jaws_JawId",
                table: "JawJawSideTeeth",
                column: "JawId",
                principalTable: "Jaws",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JawJawSideTeeth_JawSides_JawSideId",
                table: "JawJawSideTeeth",
                column: "JawSideId",
                principalTable: "JawSides",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JawJawSideTeeth_Teeth_ToothId",
                table: "JawJawSideTeeth",
                column: "ToothId",
                principalTable: "Teeth",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
