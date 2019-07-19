using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyBlog.Persistence.Migrations
{
    public partial class InitialContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedBy = table.Column<int>(nullable: false),
                    DeleteDateTime = table.Column<DateTime>(nullable: true),
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
                    table.PrimaryKey("PK_UserDetails", x => x.Id);
                    table.UniqueConstraint("AK_UserDetails_UserName", x => x.UserName);
                });

            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(maxLength: 200, nullable: false),
                    Description = table.Column<string>(nullable: false),
                    ShortDescription = table.Column<string>(maxLength: 350, nullable: false),
                    IsDraft = table.Column<bool>(nullable: false),
                    PostedDate = table.Column<DateTime>(nullable: true),
                    Tags = table.Column<string>(nullable: true),
                    CategoryID = table.Column<int>(nullable: false),
                    UserName = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Blogs_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Blogs_UserDetails_UserName",
                        column: x => x.UserName,
                        principalTable: "UserDetails",
                        principalColumn: "UserName",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_CategoryID",
                table: "Blogs",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_UserName",
                table: "Blogs",
                column: "UserName");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Name",
                table: "Categories",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserDetails_Email",
                table: "UserDetails",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Blogs");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "UserDetails");
        }
    }
}
