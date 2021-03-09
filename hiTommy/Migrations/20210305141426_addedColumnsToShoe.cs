﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace hiTommy.Migrations
{
    public partial class addedColumnsToShoe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_Shoes_Brands_BrandId",
                "Shoes");

            migrationBuilder.AlterColumn<int>(
                "BrandId",
                "Shoes",
                "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                "Description",
                "Shoes",
                "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                "PictureUrl",
                "Shoes",
                "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                "FK_Shoes_Brands_BrandId",
                "Shoes",
                "BrandId",
                "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_Shoes_Brands_BrandId",
                "Shoes");

            migrationBuilder.DropColumn(
                "Description",
                "Shoes");

            migrationBuilder.DropColumn(
                "PictureUrl",
                "Shoes");

            migrationBuilder.AlterColumn<int>(
                "BrandId",
                "Shoes",
                "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                "FK_Shoes_Brands_BrandId",
                "Shoes",
                "BrandId",
                "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}