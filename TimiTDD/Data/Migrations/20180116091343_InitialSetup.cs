using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TimiTDD.Data.Migrations
{
    public partial class InitialSetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AbsenceCategory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AbsenceReason = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbsenceCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ActivityType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Activity = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Addr = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Org = table.Column<string>(nullable: true),
                    ZIP = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    ProjectId = table.Column<int>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    EstimateAssembly = table.Column<double>(nullable: false),
                    EstimateExternal = table.Column<double>(nullable: false),
                    EstimateGarage = table.Column<double>(nullable: false),
                    EstimateMasonry = table.Column<double>(nullable: false),
                    EstimateOther = table.Column<double>(nullable: false),
                    EstimatePlating = table.Column<double>(nullable: false),
                    EstimateStender = table.Column<double>(nullable: false),
                    EstimateStructural = table.Column<double>(nullable: false),
                    EstimateTile = table.Column<double>(nullable: false),
                    EstimatefinalisingWork = table.Column<double>(nullable: false),
                    ProjectName = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.ProjectId);
                });

            migrationBuilder.CreateTable(
                name: "WorkCategory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    WorkPreformed = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkParticipation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AbsenceId = table.Column<int>(nullable: true),
                    Break = table.Column<double>(nullable: false),
                    ClientId = table.Column<int>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    DateTimeEnd = table.Column<DateTime>(nullable: false),
                    DateTimeStart = table.Column<DateTime>(nullable: false),
                    Hours = table.Column<double>(nullable: false),
                    ProjectId = table.Column<int>(nullable: true),
                    SessionState = table.Column<bool>(nullable: false),
                    UIdId = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false),
                    WorkCategoryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkParticipation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkParticipation_AbsenceCategory_AbsenceId",
                        column: x => x.AbsenceId,
                        principalTable: "AbsenceCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkParticipation_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkParticipation_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkParticipation_AspNetUsers_UIdId",
                        column: x => x.UIdId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkParticipation_WorkCategory_WorkCategoryId",
                        column: x => x.WorkCategoryId,
                        principalTable: "WorkCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkParticipation_AbsenceId",
                table: "WorkParticipation",
                column: "AbsenceId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkParticipation_ClientId",
                table: "WorkParticipation",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkParticipation_ProjectId",
                table: "WorkParticipation",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkParticipation_UIdId",
                table: "WorkParticipation",
                column: "UIdId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkParticipation_WorkCategoryId",
                table: "WorkParticipation",
                column: "WorkCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivityType");

            migrationBuilder.DropTable(
                name: "WorkParticipation");

            migrationBuilder.DropTable(
                name: "AbsenceCategory");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "WorkCategory");
        }
    }
}
