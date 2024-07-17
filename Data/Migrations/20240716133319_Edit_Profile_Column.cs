using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetCareer.Migrations
{
    /// <inheritdoc />
    public partial class Edit_Profile_Column : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobApplications_AspNetUsers_UserID",
                table: "JobApplications");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Profiles",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "JobApplications",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationStatus",
                table: "JobApplications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_JobApplications_AspNetUsers_UserID",
                table: "JobApplications",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobApplications_AspNetUsers_UserID",
                table: "JobApplications");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Profiles",
                newName: "ID");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "JobApplications",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationStatus",
                table: "JobApplications",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_JobApplications_AspNetUsers_UserID",
                table: "JobApplications",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
