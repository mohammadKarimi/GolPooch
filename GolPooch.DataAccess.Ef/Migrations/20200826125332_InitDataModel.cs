using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GolPooch.DataAccess.Ef.Migrations
{
    public partial class InitDataModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "eocn");

            migrationBuilder.CreateTable(
                name: "ChangeLog",
                columns: table => new
                {
                    ChangeLogId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Version = table.Column<string>(nullable: true),
                    Change = table.Column<string>(nullable: true),
                    InsertDateSh = table.Column<string>(nullable: true),
                    InsertDateMi = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChangeLog", x => x.ChangeLogId);
                });

            migrationBuilder.CreateTable(
                name: "Chest",
                columns: table => new
                {
                    ChestId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    Participant = table.Column<int>(nullable: false),
                    Winner = table.Column<int>(nullable: false),
                    Round = table.Column<int>(nullable: false),
                    InsertDateSh = table.Column<string>(type: "char(10)", maxLength: 10, nullable: false),
                    InsertDateMi = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chest", x => x.ChestId);
                });

            migrationBuilder.CreateTable(
                name: "Page",
                columns: table => new
                {
                    PageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Page", x => x.PageId);
                });

            migrationBuilder.CreateTable(
                name: "PaymentGateway",
                columns: table => new
                {
                    PaymentGatewayId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(nullable: false),
                    BankName = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    MerchantId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentGateway", x => x.PaymentGatewayId);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    SubTitle = table.Column<string>(nullable: true),
                    ExpireDateTime = table.Column<DateTime>(nullable: false),
                    UsageTime = table.Column<int>(nullable: false),
                    IsShow = table.Column<bool>(nullable: false),
                    InsertDateSh = table.Column<string>(type: "char(10)", maxLength: 10, nullable: false),
                    InsertDateMi = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "Region",
                columns: table => new
                {
                    RegionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Region", x => x.RegionId);
                });

            migrationBuilder.CreateTable(
                name: "ModalMessage",
                columns: table => new
                {
                    ModalMessageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PageId = table.Column<int>(nullable: false),
                    Location = table.Column<int>(nullable: false),
                    Type = table.Column<byte>(nullable: false),
                    DisplayCount = table.Column<byte>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    Href = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    ModalMessageAction = table.Column<byte>(nullable: false),
                    ExpirationDate = table.Column<DateTime>(nullable: false),
                    InsertDateSh = table.Column<string>(type: "char(10)", maxLength: 10, nullable: false),
                    InsertDateMi = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModalMessage", x => x.ModalMessageId);
                    table.ForeignKey(
                        name: "FK_ModalMessage_Page_PageId",
                        column: x => x.PageId,
                        principalTable: "Page",
                        principalColumn: "PageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Promotion",
                columns: table => new
                {
                    PromotionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    Chance = table.Column<byte>(nullable: false),
                    TotalPrice = table.Column<int>(nullable: false),
                    Discount = table.Column<int>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    Profit = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    InsertDateSh = table.Column<string>(type: "char(10)", maxLength: 10, nullable: false),
                    InsertDateMi = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promotion", x => x.PromotionId);
                    table.ForeignKey(
                        name: "FK_Promotion_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Birthdate = table.Column<string>(nullable: true),
                    BirthdateMi = table.Column<DateTime>(nullable: false),
                    PushId = table.Column<string>(nullable: true),
                    DeviceName = table.Column<string>(nullable: true),
                    RegionId = table.Column<int>(nullable: false),
                    Gender = table.Column<byte>(nullable: false),
                    ProfileAddr = table.Column<string>(nullable: true),
                    InsertDateSh = table.Column<string>(type: "char(10)", maxLength: 10, nullable: false),
                    InsertDateMi = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_User_Region_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Region",
                        principalColumn: "RegionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Purchase",
                columns: table => new
                {
                    PurchaseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PromotionId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    Chance = table.Column<byte>(nullable: false),
                    RemainedChance = table.Column<byte>(nullable: false),
                    PaymentTransactionId = table.Column<int>(nullable: false),
                    IsPayedBack = table.Column<bool>(nullable: false),
                    InsertDateSh = table.Column<string>(type: "char(10)", maxLength: 10, nullable: false),
                    InsertDateMi = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchase", x => x.PurchaseId);
                    table.ForeignKey(
                        name: "FK_Purchase_Promotion_PromotionId",
                        column: x => x.PromotionId,
                        principalTable: "Promotion",
                        principalColumn: "PromotionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Purchase_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sheet",
                columns: table => new
                {
                    SheetId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WinnerUserId = table.Column<int>(nullable: false),
                    DateStartMi = table.Column<DateTime>(nullable: false),
                    DateStartSh = table.Column<string>(nullable: true),
                    DateEndMi = table.Column<DateTime>(nullable: false),
                    DateEndSh = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsPayed = table.Column<bool>(nullable: false),
                    DatePayMi = table.Column<DateTime>(nullable: false),
                    DatePaySh = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sheet", x => x.SheetId);
                    table.ForeignKey(
                        name: "FK_Sheet_User_WinnerUserId",
                        column: x => x.WinnerUserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    TicketId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    Subject = table.Column<string>(nullable: true),
                    Content = table.Column<int>(nullable: false),
                    Answer = table.Column<int>(nullable: false),
                    AnswerDateSh = table.Column<string>(type: "char(10)", maxLength: 10, nullable: false),
                    AnswerDateMi = table.Column<DateTime>(nullable: false),
                    InsertDateSh = table.Column<string>(type: "char(10)", maxLength: 10, nullable: false),
                    InsertDateMi = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.TicketId);
                    table.ForeignKey(
                        name: "FK_Ticket_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserModalMessage",
                columns: table => new
                {
                    UserModalMessageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    ModalMessageId = table.Column<int>(nullable: false),
                    InsertDateSh = table.Column<string>(type: "char(10)", maxLength: 10, nullable: false),
                    InsertDateMi = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserModalMessage", x => x.UserModalMessageId);
                    table.ForeignKey(
                        name: "FK_UserModalMessage_ModalMessage_ModalMessageId",
                        column: x => x.ModalMessageId,
                        principalTable: "ModalMessage",
                        principalColumn: "ModalMessageId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserModalMessage_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VerificationCode",
                columns: table => new
                {
                    VerificationCodeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    Code = table.Column<int>(nullable: false),
                    ExpirationTime = table.Column<DateTime>(nullable: false),
                    IsVerified = table.Column<bool>(nullable: false),
                    InsertDateSh = table.Column<string>(type: "char(10)", maxLength: 10, nullable: false),
                    InsertDateMi = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VerificationCode", x => x.VerificationCodeId);
                    table.ForeignKey(
                        name: "FK_VerificationCode_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notification",
                schema: "eocn",
                columns: table => new
                {
                    NotificationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    To = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    Target = table.Column<byte>(nullable: false),
                    Action = table.Column<byte>(nullable: false),
                    IsSend = table.Column<bool>(nullable: false),
                    IsSuccess = table.Column<bool>(nullable: false),
                    IsDelivered = table.Column<bool>(nullable: false),
                    InsertDateSh = table.Column<string>(type: "char(10)", maxLength: 10, nullable: false),
                    InsertDateMi = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.NotificationId);
                    table.ForeignKey(
                        name: "FK_Notification_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaymentTransaction",
                columns: table => new
                {
                    PaymentTransactionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    PaymentGatewayId = table.Column<int>(nullable: false),
                    BankCardId = table.Column<int>(nullable: false),
                    PurchaseId = table.Column<int>(nullable: true),
                    Price = table.Column<int>(nullable: false),
                    IsSuccess = table.Column<bool>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    Authority = table.Column<string>(nullable: true),
                    TrackingId = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    InsertDateSh = table.Column<string>(type: "char(10)", maxLength: 10, nullable: false),
                    InsertDateMi = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentTransaction", x => x.PaymentTransactionId);
                    table.ForeignKey(
                        name: "FK_PaymentTransaction_PaymentGateway_PaymentGatewayId",
                        column: x => x.PaymentGatewayId,
                        principalTable: "PaymentGateway",
                        principalColumn: "PaymentGatewayId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaymentTransaction_Purchase_PurchaseId",
                        column: x => x.PurchaseId,
                        principalTable: "Purchase",
                        principalColumn: "PurchaseId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PaymentTransaction_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserChance",
                columns: table => new
                {
                    ChanceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Order = table.Column<int>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: true),
                    PurchaseId = table.Column<int>(nullable: false),
                    SheetId = table.Column<int>(nullable: true),
                    InsertDateSh = table.Column<string>(type: "char(10)", maxLength: 10, nullable: false),
                    InsertDateMi = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserChance", x => x.ChanceId);
                    table.ForeignKey(
                        name: "FK_UserChance_Purchase_PurchaseId",
                        column: x => x.PurchaseId,
                        principalTable: "Purchase",
                        principalColumn: "PurchaseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserChance_Sheet_SheetId",
                        column: x => x.SheetId,
                        principalTable: "Sheet",
                        principalColumn: "SheetId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserChance_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ModalMessage_PageId",
                table: "ModalMessage",
                column: "PageId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentTransaction_PaymentGatewayId",
                table: "PaymentTransaction",
                column: "PaymentGatewayId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentTransaction_PurchaseId",
                table: "PaymentTransaction",
                column: "PurchaseId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentTransaction_UserId",
                table: "PaymentTransaction",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Promotion_ProductId",
                table: "Promotion",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_PromotionId",
                table: "Purchase",
                column: "PromotionId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_UserId",
                table: "Purchase",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Sheet_WinnerUserId",
                table: "Sheet",
                column: "WinnerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_UserId",
                table: "Ticket",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_User_RegionId",
                table: "User",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserChance_PurchaseId",
                table: "UserChance",
                column: "PurchaseId");

            migrationBuilder.CreateIndex(
                name: "IX_UserChance_SheetId",
                table: "UserChance",
                column: "SheetId");

            migrationBuilder.CreateIndex(
                name: "IX_UserChance_UserId",
                table: "UserChance",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserModalMessage_ModalMessageId",
                table: "UserModalMessage",
                column: "ModalMessageId");

            migrationBuilder.CreateIndex(
                name: "IX_UserModalMessage_UserId",
                table: "UserModalMessage",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_VerificationCode_UserId",
                table: "VerificationCode",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_UserId",
                schema: "eocn",
                table: "Notification",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChangeLog");

            migrationBuilder.DropTable(
                name: "Chest");

            migrationBuilder.DropTable(
                name: "PaymentTransaction");

            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "UserChance");

            migrationBuilder.DropTable(
                name: "UserModalMessage");

            migrationBuilder.DropTable(
                name: "VerificationCode");

            migrationBuilder.DropTable(
                name: "Notification",
                schema: "eocn");

            migrationBuilder.DropTable(
                name: "PaymentGateway");

            migrationBuilder.DropTable(
                name: "Purchase");

            migrationBuilder.DropTable(
                name: "Sheet");

            migrationBuilder.DropTable(
                name: "ModalMessage");

            migrationBuilder.DropTable(
                name: "Promotion");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Page");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Region");
        }
    }
}
