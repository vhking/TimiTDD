using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TimiTDD.Migrations
{
    public partial class db_Changes_WP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkParticipation_AspNetUsers_UIdId",
                table: "WorkParticipation");

            migrationBuilder.DropIndex(
                name: "IX_WorkParticipation_UIdId",
                table: "WorkParticipation");

            migrationBuilder.DropColumn(
                name: "UIdId",
                table: "WorkParticipation");

            migrationBuilder.RenameColumn(
                name: "SessionState",
                table: "WorkParticipation",
                newName: "Session");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "WorkParticipation",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_WorkParticipation_UserId",
                table: "WorkParticipation",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkParticipation_AspNetUsers_UserId",
                table: "WorkParticipation",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkParticipation_AspNetUsers_UserId",
                table: "WorkParticipation");

            migrationBuilder.DropIndex(
                name: "IX_WorkParticipation_UserId",
                table: "WorkParticipation");

            migrationBuilder.RenameColumn(
                name: "Session",
                table: "WorkParticipation",
                newName: "SessionState");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "WorkParticipation",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "UIdId",
                table: "WorkParticipation",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkParticipation_UIdId",
                table: "WorkParticipation",
                column: "UIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkParticipation_AspNetUsers_UIdId",
                table: "WorkParticipation",
                column: "UIdId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
