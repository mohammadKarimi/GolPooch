using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GolPooch.DataAccess.Ef.Migrations
{
    public partial class EditUserVerficationCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VerificationCode_User_UserId",
                schema: "Base",
                table: "VerificationCode");

            migrationBuilder.DropIndex(
                name: "IX_VerificationCode_UserId",
                schema: "Base",
                table: "VerificationCode");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "Base",
                table: "VerificationCode");

            migrationBuilder.DropColumn(
                name: "OsType",
                schema: "Base",
                table: "User");

            migrationBuilder.AddColumn<DateTime>(
                name: "UsedTime",
                schema: "Base",
                table: "VerificationCode",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UsedTime",
                schema: "Base",
                table: "VerificationCode");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                schema: "Base",
                table: "VerificationCode",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OsType",
                schema: "Base",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_VerificationCode_UserId",
                schema: "Base",
                table: "VerificationCode",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_VerificationCode_User_UserId",
                schema: "Base",
                table: "VerificationCode",
                column: "UserId",
                principalSchema: "Base",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
