using Microsoft.EntityFrameworkCore.Migrations;

namespace BarbieFashion.Migrations
{
    public partial class ParentsAttribute_in_InfoModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InfoModels_Parents_ParentsId",
                table: "InfoModels");

            migrationBuilder.DropIndex(
                name: "IX_InfoModels_ParentsId",
                table: "InfoModels");

            migrationBuilder.DropColumn(
                name: "ParentsId",
                table: "InfoModels");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Parents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InfoModelId",
                table: "Parents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Personality",
                table: "InfoModels",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Parents_InfoModelId",
                table: "Parents",
                column: "InfoModelId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Parents_InfoModels_InfoModelId",
                table: "Parents",
                column: "InfoModelId",
                principalTable: "InfoModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parents_InfoModels_InfoModelId",
                table: "Parents");

            migrationBuilder.DropIndex(
                name: "IX_Parents_InfoModelId",
                table: "Parents");

            migrationBuilder.DropColumn(
                name: "InfoModelId",
                table: "Parents");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Parents",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Personality",
                table: "InfoModels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParentsId",
                table: "InfoModels",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InfoModels_ParentsId",
                table: "InfoModels",
                column: "ParentsId");

            migrationBuilder.AddForeignKey(
                name: "FK_InfoModels_Parents_ParentsId",
                table: "InfoModels",
                column: "ParentsId",
                principalTable: "Parents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
