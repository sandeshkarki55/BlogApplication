using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyBlog.Persistence.Migrations
{
    public partial class userdetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Blogs",
                newName: "UserName");

            migrationBuilder.CreateTable(
                name: "UserDetail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: true),
                    UserName = table.Column<string>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(maxLength: 75, nullable: false),
                    Address = table.Column<string>(maxLength: 50, nullable: true),
                    LinkedinUrl = table.Column<string>(nullable: true),
                    FacebookUrl = table.Column<string>(nullable: true),
                    GithubUrl = table.Column<string>(nullable: true),
                    TwitterUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDetail", x => x.Id);
                    table.UniqueConstraint("AK_UserDetail_UserName", x => x.UserName);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_UserName",
                table: "Blogs",
                column: "UserName");

            migrationBuilder.CreateIndex(
                name: "IX_UserDetail_Email",
                table: "UserDetail",
                column: "Email",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_UserDetail_UserName",
                table: "Blogs",
                column: "UserName",
                principalTable: "UserDetail",
                principalColumn: "UserName",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_UserDetail_UserName",
                table: "Blogs");

            migrationBuilder.DropTable(
                name: "UserDetail");

            migrationBuilder.DropIndex(
                name: "IX_Blogs_UserName",
                table: "Blogs");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Blogs",
                newName: "UserId");
        }
    }
}
