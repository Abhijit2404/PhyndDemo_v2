using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace PhyndDemo_v2.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "__efmigrationshistory",
                columns: table => new
                {
                    MigrationId = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    ProductVersion = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.MigrationId);
                });

            migrationBuilder.CreateTable(
                name: "history",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    action = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    onDatabase = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    actionTime = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    query = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    createdBy = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_history", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "hospital",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    addressLine1 = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    addressLine2 = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    addressLine3 = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    zipCode = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    city = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    state = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    country = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hospital", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "program",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    userId = table.Column<int>(type: "int(11)", nullable: true),
                    createdOn = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    modifiedOn = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    isDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_program", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "role",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    isDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    firstName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    lastName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    isDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    userHospitalId = table.Column<int>(type: "int(11)", nullable: false),
                    createdOn = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    modifiedOn = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "provider",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    firstName = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    middleName = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    lastName = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    userId = table.Column<int>(type: "int(11)", nullable: true),
                    createdOn = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    modifiedOn = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    isDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    hospitalId = table.Column<int>(type: "int(11)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_provider", x => x.id);
                    table.ForeignKey(
                        name: "provider_ibfk_1",
                        column: x => x.hospitalId,
                        principalTable: "hospital",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "userrole",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    roleId = table.Column<int>(type: "int(11)", nullable: false),
                    userId = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userrole", x => x.id);
                    table.ForeignKey(
                        name: "userrole_ibfk_1",
                        column: x => x.roleId,
                        principalTable: "role",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "userrole_ibfk_2",
                        column: x => x.userId,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "providerprogram",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    programId = table.Column<int>(type: "int(11)", nullable: true),
                    providerId = table.Column<int>(type: "int(11)", nullable: true),
                    isDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    createdOn = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    modifiedOn = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_providerprogram", x => x.id);
                    table.ForeignKey(
                        name: "providerprogram_ibfk_1",
                        column: x => x.programId,
                        principalTable: "program",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "providerprogram_ibfk_2",
                        column: x => x.providerId,
                        principalTable: "provider",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "provider_ibfk_1",
                table: "provider",
                column: "hospitalId");

            migrationBuilder.CreateIndex(
                name: "providerprogram_ibfk_1",
                table: "providerprogram",
                column: "programId");

            migrationBuilder.CreateIndex(
                name: "providerprogram_ibfk_2",
                table: "providerprogram",
                column: "providerId");

            migrationBuilder.CreateIndex(
                name: "userHospitalId",
                table: "user",
                column: "userHospitalId");

            migrationBuilder.CreateIndex(
                name: "roleId",
                table: "userrole",
                column: "roleId");

            migrationBuilder.CreateIndex(
                name: "userId",
                table: "userrole",
                column: "userId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "__efmigrationshistory");

            migrationBuilder.DropTable(
                name: "history");

            migrationBuilder.DropTable(
                name: "providerprogram");

            migrationBuilder.DropTable(
                name: "userrole");

            migrationBuilder.DropTable(
                name: "program");

            migrationBuilder.DropTable(
                name: "provider");

            migrationBuilder.DropTable(
                name: "role");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "hospital");
        }
    }
}
