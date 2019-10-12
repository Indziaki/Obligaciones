using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Obligaciones.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    AddressId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContributorId = table.Column<long>(nullable: false),
                    Street = table.Column<string>(nullable: true),
                    Ext = table.Column<string>(nullable: true),
                    Int = table.Column<string>(nullable: true),
                    Zip = table.Column<string>(nullable: true),
                    Suburb = table.Column<string>(nullable: true),
                    Town = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.AddressId);
                });

            migrationBuilder.CreateTable(
                name: "Debts",
                columns: table => new
                {
                    DebtId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContributorId = table.Column<long>(nullable: false),
                    ObligationId = table.Column<long>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    TaxType = table.Column<int>(nullable: false),
                    Origin = table.Column<int>(nullable: false),
                    Total = table.Column<double>(nullable: false),
                    Validity = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Debts", x => x.DebtId);
                });

            migrationBuilder.CreateTable(
                name: "Estates",
                columns: table => new
                {
                    EstateId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContributorId = table.Column<long>(nullable: false),
                    Key = table.Column<string>(nullable: true),
                    Area = table.Column<double>(nullable: false),
                    Construction = table.Column<double>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estates", x => x.EstateId);
                });

            migrationBuilder.CreateTable(
                name: "Obligations",
                columns: table => new
                {
                    ObligationId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Key = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    PersonType = table.Column<int>(nullable: false),
                    Valitity = table.Column<DateTime>(nullable: false),
                    Fundament = table.Column<string>(nullable: true),
                    AllowUpdates = table.Column<bool>(nullable: false),
                    ApplyTaxes = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Obligations", x => x.ObligationId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "WorkLoads",
                columns: table => new
                {
                    WorkLoadId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<long>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkLoads", x => x.WorkLoadId);
                    table.ForeignKey(
                        name: "FK_WorkLoads_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkLoadRegistries",
                columns: table => new
                {
                    WorkLoadRegistryId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    WorkLoadId = table.Column<long>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    RFC = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkLoadRegistries", x => x.WorkLoadRegistryId);
                    table.ForeignKey(
                        name: "FK_WorkLoadRegistries_WorkLoads_WorkLoadId",
                        column: x => x.WorkLoadId,
                        principalTable: "WorkLoads",
                        principalColumn: "WorkLoadId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contributors",
                columns: table => new
                {
                    ContributorId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RFC = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    WorkLoadRegistryId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contributors", x => x.ContributorId);
                    table.ForeignKey(
                        name: "FK_Contributors_WorkLoadRegistries_WorkLoadRegistryId",
                        column: x => x.WorkLoadRegistryId,
                        principalTable: "WorkLoadRegistries",
                        principalColumn: "WorkLoadRegistryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contributors_WorkLoadRegistryId",
                table: "Contributors",
                column: "WorkLoadRegistryId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkLoadRegistries_WorkLoadId",
                table: "WorkLoadRegistries",
                column: "WorkLoadId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkLoads_UserId",
                table: "WorkLoads",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Contributors");

            migrationBuilder.DropTable(
                name: "Debts");

            migrationBuilder.DropTable(
                name: "Estates");

            migrationBuilder.DropTable(
                name: "Obligations");

            migrationBuilder.DropTable(
                name: "WorkLoadRegistries");

            migrationBuilder.DropTable(
                name: "WorkLoads");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
