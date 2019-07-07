using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyBlog.Persistence.Migrations
{
    public partial class userdetaildelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_UserDetail_UserName",
                table: "Blogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserDetail",
                table: "UserDetail");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_UserDetail_UserName",
                table: "UserDetail");

            migrationBuilder.RenameTable(
                name: "UserDetail",
                newName: "UserDetails");

            migrationBuilder.RenameIndex(
                name: "IX_UserDetail_Email",
                table: "UserDetails",
                newName: "IX_UserDetails_Email");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteDateTime",
                table: "UserDetails",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedBy",
                table: "UserDetails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "UserDetails",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserDetails",
                table: "UserDetails",
                column: "Id");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_UserDetails_UserName",
                table: "UserDetails",
                column: "UserName");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_UserDetails_UserName",
                table: "Blogs",
                column: "UserName",
                principalTable: "UserDetails",
                principalColumn: "UserName",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_UserDetails_UserName",
                table: "Blogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserDetails",
                table: "UserDetails");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_UserDetails_UserName",
                table: "UserDetails");

            migrationBuilder.DropColumn(
                name: "DeleteDateTime",
                table: "UserDetails");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "UserDetails");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "UserDetails");

            migrationBuilder.RenameTable(
                name: "UserDetails",
                newName: "UserDetail");

            migrationBuilder.RenameIndex(
                name: "IX_UserDetails_Email",
                table: "UserDetail",
                newName: "IX_UserDetail_Email");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserDetail",
                table: "UserDetail",
                column: "Id");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_UserDetail_UserName",
                table: "UserDetail",
                column: "UserName");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_UserDetail_UserName",
                table: "Blogs",
                column: "UserName",
                principalTable: "UserDetail",
                principalColumn: "UserName",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
