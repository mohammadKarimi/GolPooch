using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GolPooch.DataAccess.Ef.Migrations
{
    public partial class RenameVerficationCode2Authenticate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VerificationCode",
                schema: "Base");

            migrationBuilder.CreateTable(
                name: "Authenticate",
                schema: "Base",
                columns: table => new
                {
                    AuthenticateId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MobileNumber = table.Column<long>(nullable: false),
                    PinCode = table.Column<int>(nullable: false),
                    IsUsed = table.Column<bool>(nullable: false),
                    InsertDateMi = table.Column<DateTime>(nullable: false),
                    InsertDateSh = table.Column<string>(type: "char(10)", maxLength: 10, nullable: true),
                    ExpirationTime = table.Column<DateTime>(nullable: false),
                    UsedTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authenticate", x => x.AuthenticateId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Authenticate",
                schema: "Base");

            migrationBuilder.CreateTable(
                name: "VerificationCode",
                schema: "Base",
                columns: table => new
                {
                    VerificationCodeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpirationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InsertDateMi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InsertDateSh = table.Column<string>(type: "char(10)", maxLength: 10, nullable: true),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false),
                    MobileNumber = table.Column<long>(type: "bigint", nullable: false),
                    PinCode = table.Column<int>(type: "int", nullable: false),
                    UsedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VerificationCode", x => x.VerificationCodeId);
                });
        }
    }
}
