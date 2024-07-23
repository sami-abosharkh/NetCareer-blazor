using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetCareer.Migrations
{
    /// <inheritdoc />
    public partial class Edit_Profile_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_Educations_EducationID",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_EducationID",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "EducationID",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "ExperienceYears",
                table: "Profiles");

            migrationBuilder.AlterColumn<string>(
                name: "ProfilePicture",
                table: "Profiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ProfilePicture",
                table: "Profiles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "EducationID",
                table: "Profiles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExperienceYears",
                table: "Profiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_EducationID",
                table: "Profiles",
                column: "EducationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_Educations_EducationID",
                table: "Profiles",
                column: "EducationID",
                principalTable: "Educations",
                principalColumn: "Id");
        }
    }
}
