using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assess.Migrations
{
    /// <inheritdoc />
    public partial class Test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CommunityProject",
                columns: table => new
                {
                    CommunityProjectsID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Decription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalFundsRequired = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalFundsRaised = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SponsoredAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunityProject", x => x.CommunityProjectsID);
                });

            migrationBuilder.CreateTable(
                name: "LanguageCultures",
                columns: table => new
                {
                    LanguageCultureID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CultureNameCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguageCultures", x => x.LanguageCultureID);
                });

            migrationBuilder.CreateTable(
                name: "PaymentFrequencies",
                columns: table => new
                {
                    PaymentFrequencyID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Event_Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentFrequencies", x => x.PaymentFrequencyID);
                });

            migrationBuilder.CreateTable(
                name: "ProductsTypes",
                columns: table => new
                {
                    ProductsTypeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Event_Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsTypes", x => x.ProductsTypeID);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    UserRoleID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.UserRoleID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CellphoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoginTries = table.Column<int>(type: "int", nullable: false),
                    IsSuspended = table.Column<bool>(type: "bit", nullable: false),
                    IsEmailVerified = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LocalizationValues",
                columns: table => new
                {
                    LocalizationValueID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LanguageCultureID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KeyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalizationValues", x => x.LocalizationValueID);
                    table.ForeignKey(
                        name: "FK_LocalizationValues_LanguageCultures_LanguageCultureID",
                        column: x => x.LanguageCultureID,
                        principalTable: "LanguageCultures",
                        principalColumn: "LanguageCultureID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LinkUserRole",
                columns: table => new
                {
                    LinkUserRoleID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserRoleID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinkUserRole", x => x.LinkUserRoleID);
                    table.ForeignKey(
                        name: "FK_LinkUserRole_UserRole_UserRoleID",
                        column: x => x.UserRoleID,
                        principalTable: "UserRole",
                        principalColumn: "UserRoleID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LinkUserRole_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SponsorshipPlan",
                columns: table => new
                {
                    SponsorshipPlanID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Decription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OnceOff = table.Column<bool>(type: "bit", nullable: true),
                    SponsorAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DateActivated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentFrequencyID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    DateSuspend = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SponsorshipPlan", x => x.SponsorshipPlanID);
                    table.ForeignKey(
                        name: "FK_SponsorshipPlan_PaymentFrequencies_PaymentFrequencyID",
                        column: x => x.PaymentFrequencyID,
                        principalTable: "PaymentFrequencies",
                        principalColumn: "PaymentFrequencyID");
                    table.ForeignKey(
                        name: "FK_SponsorshipPlan_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserProductsInformation",
                columns: table => new
                {
                    UserProductsInformationID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOpened = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AmountLimit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AvailableBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductsTypeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProductsInformation", x => x.UserProductsInformationID);
                    table.ForeignKey(
                        name: "FK_UserProductsInformation_ProductsTypes_ProductsTypeID",
                        column: x => x.ProductsTypeID,
                        principalTable: "ProductsTypes",
                        principalColumn: "ProductsTypeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserProductsInformation_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectsSponsorTransactions",
                columns: table => new
                {
                    ProjectsSponsorTransactionID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Decription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SponsorAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SponsoredAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ProductsTypeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SponsorshipPlanID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectsSponsorTransactions", x => x.ProjectsSponsorTransactionID);
                    table.ForeignKey(
                        name: "FK_ProjectsSponsorTransactions_ProductsTypes_ProductsTypeID",
                        column: x => x.ProductsTypeID,
                        principalTable: "ProductsTypes",
                        principalColumn: "ProductsTypeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectsSponsorTransactions_SponsorshipPlan_SponsorshipPlanID",
                        column: x => x.SponsorshipPlanID,
                        principalTable: "SponsorshipPlan",
                        principalColumn: "SponsorshipPlanID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_LinkUserRole_UserID",
                table: "LinkUserRole",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_LinkUserRole_UserRoleID",
                table: "LinkUserRole",
                column: "UserRoleID");

            migrationBuilder.CreateIndex(
                name: "IX_LocalizationValues_LanguageCultureID",
                table: "LocalizationValues",
                column: "LanguageCultureID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectsSponsorTransactions_ProductsTypeID",
                table: "ProjectsSponsorTransactions",
                column: "ProductsTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectsSponsorTransactions_SponsorshipPlanID",
                table: "ProjectsSponsorTransactions",
                column: "SponsorshipPlanID");

            migrationBuilder.CreateIndex(
                name: "IX_SponsorshipPlan_PaymentFrequencyID",
                table: "SponsorshipPlan",
                column: "PaymentFrequencyID");

            migrationBuilder.CreateIndex(
                name: "IX_SponsorshipPlan_UserID",
                table: "SponsorshipPlan",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_UserProductsInformation_ProductsTypeID",
                table: "UserProductsInformation",
                column: "ProductsTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_UserProductsInformation_UserID",
                table: "UserProductsInformation",
                column: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CommunityProject");

            migrationBuilder.DropTable(
                name: "LinkUserRole");

            migrationBuilder.DropTable(
                name: "LocalizationValues");

            migrationBuilder.DropTable(
                name: "ProjectsSponsorTransactions");

            migrationBuilder.DropTable(
                name: "UserProductsInformation");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "LanguageCultures");

            migrationBuilder.DropTable(
                name: "SponsorshipPlan");

            migrationBuilder.DropTable(
                name: "ProductsTypes");

            migrationBuilder.DropTable(
                name: "PaymentFrequencies");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
