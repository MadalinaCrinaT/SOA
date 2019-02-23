using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialApp.Data.Migrations
{
	public partial class ActivityWithoutGroup : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_ActivityTypes_Groups_GroupId",
				table: "ActivityTypes");

			migrationBuilder.DropIndex(
				name: "IX_ActivityTypes_GroupId",
				table: "ActivityTypes");

			migrationBuilder.DropColumn(
				name: "GroupId",
				table: "ActivityTypes");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AddColumn<int>(
				name: "GroupId",
				table: "ActivityTypes",
				nullable: false,
				defaultValue: 0);

			migrationBuilder.CreateIndex(
				name: "IX_ActivityTypes_GroupId",
				table: "ActivityTypes",
				column: "GroupId");

			migrationBuilder.AddForeignKey(
				name: "FK_ActivityTypes_Groups_GroupId",
				table: "ActivityTypes",
				column: "GroupId",
				principalTable: "Groups",
				principalColumn: "GroupId",
				onDelete: ReferentialAction.Cascade);
		}
	}
}
