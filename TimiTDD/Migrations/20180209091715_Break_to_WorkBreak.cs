using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TimiTDD.Migrations
{
    public partial class Break_to_WorkBreak : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Break",
                table: "WorkParticipation",
                newName: "WorkBreak");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WorkBreak",
                table: "WorkParticipation",
                newName: "Break");
        }
    }
}
