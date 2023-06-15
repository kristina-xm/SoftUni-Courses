using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP_ForumApp.Data.Migrations;

public partial class CreateAndSeedDb : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Posts",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                Content = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Posts", x => x.Id);
            });

        migrationBuilder.InsertData(
            table: "Posts",
            columns: new[] { "Id", "Content", "Title" },
            values: new object[] { new Guid("3c5c5aa8-8351-4c01-9753-646fc896efa7"), "Lorem ipsum dolor sit amet, con.", "Title 2" });

        migrationBuilder.InsertData(
            table: "Posts",
            columns: new[] { "Id", "Content", "Title" },
            values: new object[] { new Guid("87422e12-19b4-4e1e-984e-3b70cbb0cbd8"), "Lorem ipsum dolor sit amet, con.rem ipsum dolor si piscing el ed tempor mattis quam, at porttit", "Title 3" });

        migrationBuilder.InsertData(
            table: "Posts",
            columns: new[] { "Id", "Content", "Title" },
            values: new object[] { new Guid("e400d0c0-fabf-45dd-9941-3bf2d122fcd7"), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed tempor mattis quam, at porttitor metus.", "Title 1" });
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Posts");
    }
}
