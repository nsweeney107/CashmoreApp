using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CashmoreApp.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contract",
                columns: table => new
                {
                    ContractID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ContractEndDate = table.Column<DateTime>(nullable: false),
                    ContractProductLine = table.Column<string>(nullable: false),
                    ContractPurchaseOrder = table.Column<string>(nullable: false),
                    ContractStartDate = table.Column<DateTime>(nullable: false),
                    ContractStatus = table.Column<string>(nullable: true),
                    ContractValue = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contract", x => x.ContractID);
                });

            migrationBuilder.CreateTable(
                name: "Entity",
                columns: table => new
                {
                    EntityID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EntityAddress1 = table.Column<string>(nullable: false),
                    EntityAddress2 = table.Column<string>(nullable: true),
                    EntityCity = table.Column<string>(nullable: false),
                    EntityCountry = table.Column<string>(nullable: false),
                    EntityName = table.Column<string>(nullable: false),
                    EntityPhoneNumber = table.Column<string>(nullable: false),
                    EntityState = table.Column<string>(nullable: false),
                    EntityType = table.Column<int>(nullable: false),
                    EntityZipcode = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entity", x => x.EntityID);
                });

            migrationBuilder.CreateTable(
                name: "EntityToContract",
                columns: table => new
                {
                    EntityID = table.Column<int>(nullable: false),
                    ContractID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityToContract", x => new { x.EntityID, x.ContractID });
                    table.ForeignKey(
                        name: "FK_EntityToContract_Contract_ContractID",
                        column: x => x.ContractID,
                        principalTable: "Contract",
                        principalColumn: "ContractID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EntityToContract_Entity_EntityID",
                        column: x => x.EntityID,
                        principalTable: "Entity",
                        principalColumn: "EntityID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EntityID = table.Column<int>(nullable: false),
                    UserAccessLevel = table.Column<int>(nullable: false),
                    UserEmail = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(name: "First Name", maxLength: 50, nullable: false),
                    UserLastName = table.Column<string>(maxLength: 50, nullable: false),
                    UserPassword = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_User_Entity_EntityID",
                        column: x => x.EntityID,
                        principalTable: "Entity",
                        principalColumn: "EntityID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Signatures",
                columns: table => new
                {
                    SignaturesID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ContractID = table.Column<int>(nullable: false),
                    ContractType = table.Column<int>(nullable: false),
                    HospitalSignatureUserID = table.Column<int>(nullable: true),
                    VendorSignatureUserID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Signatures", x => x.SignaturesID);
                    table.ForeignKey(
                        name: "FK_Signatures_Contract_ContractID",
                        column: x => x.ContractID,
                        principalTable: "Contract",
                        principalColumn: "ContractID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Signatures_User_HospitalSignatureUserID",
                        column: x => x.HospitalSignatureUserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Signatures_User_VendorSignatureUserID",
                        column: x => x.VendorSignatureUserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EntityToContract_ContractID",
                table: "EntityToContract",
                column: "ContractID");

            migrationBuilder.CreateIndex(
                name: "IX_Signatures_ContractID",
                table: "Signatures",
                column: "ContractID");

            migrationBuilder.CreateIndex(
                name: "IX_Signatures_HospitalSignatureUserID",
                table: "Signatures",
                column: "HospitalSignatureUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Signatures_VendorSignatureUserID",
                table: "Signatures",
                column: "VendorSignatureUserID");

            migrationBuilder.CreateIndex(
                name: "IX_User_EntityID",
                table: "User",
                column: "EntityID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EntityToContract");

            migrationBuilder.DropTable(
                name: "Signatures");

            migrationBuilder.DropTable(
                name: "Contract");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Entity");
        }
    }
}
