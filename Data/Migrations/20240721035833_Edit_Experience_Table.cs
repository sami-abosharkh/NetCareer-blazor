using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetCareer.Migrations
{
    /// <inheritdoc />
    public partial class Edit_Experience_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Experiences_AspNetUsers_UserID",
                table: "Experiences");

            migrationBuilder.DropIndex(
                name: "IX_Experiences_UserID",
                table: "Experiences");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Experiences");

            migrationBuilder.AddColumn<int>(
                name: "ProfileID",
                table: "Experiences",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfileID",
                table: "Experiences");

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "Experiences",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Experiences_UserID",
                table: "Experiences",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Experiences_AspNetUsers_UserID",
                table: "Experiences",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
