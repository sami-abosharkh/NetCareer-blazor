using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetCareer.Migrations
{
    /// <inheritdoc />
    public partial class Change_Education_Column : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Educations_AspNetUsers_UserID",
                table: "Educations");

            migrationBuilder.DropIndex(
                name: "IX_Educations_UserID",
                table: "Educations");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Educations");

            migrationBuilder.AddColumn<int>(
                name: "ProfileID",
                table: "Educations",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfileID",
                table: "Educations");

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "Educations",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Educations_UserID",
                table: "Educations",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Educations_AspNetUsers_UserID",
                table: "Educations",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
