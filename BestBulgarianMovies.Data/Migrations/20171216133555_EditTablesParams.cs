using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BestBulgarianMovies.Data.Migrations
{
    public partial class EditTablesParams : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ThumbnailUrl",
                table: "Movies",
                maxLength: 2047,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ThumbnailUrl",
                table: "Articles",
                maxLength: 2040,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ThumbnailUrl",
                table: "Movies",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 2047);

            migrationBuilder.AlterColumn<string>(
                name: "ThumbnailUrl",
                table: "Articles",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 2040);
        }
    }
}
