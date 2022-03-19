using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetFlex.DAL.Migrations
{
    public partial class ChangeEntitiesMigrate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Poster",
                table: "Serials",
                type: "bytea",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Poster",
                table: "Films",
                type: "bytea",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Preview",
                table: "Films",
                type: "bytea",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PreviewVideo",
                table: "Episodes",
                type: "bytea",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Poster",
                table: "Serials");

            migrationBuilder.DropColumn(
                name: "Poster",
                table: "Films");

            migrationBuilder.DropColumn(
                name: "Preview",
                table: "Films");

            migrationBuilder.DropColumn(
                name: "PreviewVideo",
                table: "Episodes");
        }
    }
}
