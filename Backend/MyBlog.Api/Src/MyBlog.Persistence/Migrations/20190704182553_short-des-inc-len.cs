using Microsoft.EntityFrameworkCore.Migrations;

namespace MyBlog.Persistence.Migrations
{
    public partial class shortdesinclen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ShortDescription",
                table: "Blogs",
                maxLength: 350,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 200);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ShortDescription",
                table: "Blogs",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 350);
        }
    }
}
