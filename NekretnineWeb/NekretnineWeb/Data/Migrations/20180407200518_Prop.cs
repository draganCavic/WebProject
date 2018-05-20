using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace NekretnineWeb.Data.Migrations
{
    public partial class Prop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Mail",
                table: "Properties",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tel",
                table: "Properties",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mail",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "Tel",
                table: "Properties");
        }
    }
}
