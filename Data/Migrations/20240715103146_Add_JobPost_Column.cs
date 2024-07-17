using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetCareer.Migrations
{
    /// <inheritdoc />
    public partial class Add_JobPost_Column : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "JobPosts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Position",
                table: "JobPosts");
        }
    }
}
