using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TimiTDD.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkParticipation_ActivityType_ActivityTypeId",
                table: "WorkParticipation");

            migrationBuilder.RenameColumn(
                name: "WorkPreformed",
                table: "WorkCategory",
                newName: "WorkPerformed");

            migrationBuilder.AlterColumn<int>(
                name: "ActivityTypeId",
                table: "WorkParticipation",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkParticipation_ActivityType_ActivityTypeId",
                table: "WorkParticipation",
                column: "ActivityTypeId",
                principalTable: "ActivityType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkParticipation_ActivityType_ActivityTypeId",
                table: "WorkParticipation");

            migrationBuilder.RenameColumn(
                name: "WorkPerformed",
                table: "WorkCategory",
                newName: "WorkPreformed");

            migrationBuilder.AlterColumn<int>(
                name: "ActivityTypeId",
                table: "WorkParticipation",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_WorkParticipation_ActivityType_ActivityTypeId",
                table: "WorkParticipation",
                column: "ActivityTypeId",
                principalTable: "ActivityType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
