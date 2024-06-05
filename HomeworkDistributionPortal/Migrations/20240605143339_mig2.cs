using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeworkDistributionPortal.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deliveryies_AspNetUsers_AppUsersId",
                table: "Deliveryies");

            migrationBuilder.DropForeignKey(
                name: "FK_Deliveryies_AspNetUsers_StudentId",
                table: "Deliveryies");

            migrationBuilder.DropForeignKey(
                name: "FK_Deliveryies_Homeworks_HomeworkId",
                table: "Deliveryies");

            migrationBuilder.DropForeignKey(
                name: "FK_Deliveryies_Homeworks_HomeworksHomeworkId",
                table: "Deliveryies");

            migrationBuilder.DropIndex(
                name: "IX_Deliveryies_AppUsersId",
                table: "Deliveryies");

            migrationBuilder.DropIndex(
                name: "IX_Deliveryies_HomeworksHomeworkId",
                table: "Deliveryies");

            migrationBuilder.DropColumn(
                name: "AppUsersId",
                table: "Deliveryies");

            migrationBuilder.DropColumn(
                name: "HomeworksHomeworkId",
                table: "Deliveryies");

            migrationBuilder.AddForeignKey(
                name: "FK_Deliveryies_AspNetUsers_StudentId",
                table: "Deliveryies",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Deliveryies_Homeworks_HomeworkId",
                table: "Deliveryies",
                column: "HomeworkId",
                principalTable: "Homeworks",
                principalColumn: "HomeworkId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deliveryies_AspNetUsers_StudentId",
                table: "Deliveryies");

            migrationBuilder.DropForeignKey(
                name: "FK_Deliveryies_Homeworks_HomeworkId",
                table: "Deliveryies");

            migrationBuilder.AddColumn<string>(
                name: "AppUsersId",
                table: "Deliveryies",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "HomeworksHomeworkId",
                table: "Deliveryies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Deliveryies_AppUsersId",
                table: "Deliveryies",
                column: "AppUsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Deliveryies_HomeworksHomeworkId",
                table: "Deliveryies",
                column: "HomeworksHomeworkId");

            migrationBuilder.AddForeignKey(
                name: "FK_Deliveryies_AspNetUsers_AppUsersId",
                table: "Deliveryies",
                column: "AppUsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Deliveryies_AspNetUsers_StudentId",
                table: "Deliveryies",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Deliveryies_Homeworks_HomeworkId",
                table: "Deliveryies",
                column: "HomeworkId",
                principalTable: "Homeworks",
                principalColumn: "HomeworkId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Deliveryies_Homeworks_HomeworksHomeworkId",
                table: "Deliveryies",
                column: "HomeworksHomeworkId",
                principalTable: "Homeworks",
                principalColumn: "HomeworkId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
