using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialApp.Data.Migrations
{
	public partial class DeleteCascadeUnrestrictedGroupActivityTable : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_GroupActivities_ActivityTypes_ActivityId",
				table: "GroupActivities");

			migrationBuilder.DropForeignKey(
				name: "FK_GroupActivities_Groups_GroupId",
				table: "GroupActivities");

			migrationBuilder.AddForeignKey(
				name: "FK_GroupActivities_ActivityTypes_ActivityId",
				table: "GroupActivities",
				column: "ActivityId",
				principalTable: "ActivityTypes",
				principalColumn: "ActivityId",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_GroupActivities_Groups_GroupId",
				table: "GroupActivities",
				column: "GroupId",
				principalTable: "Groups",
				principalColumn: "GroupId",
				onDelete: ReferentialAction.Cascade);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_GroupActivities_ActivityTypes_ActivityId",
				table: "GroupActivities");

			migrationBuilder.DropForeignKey(
				name: "FK_GroupActivities_Groups_GroupId",
				table: "GroupActivities");

			migrationBuilder.AddForeignKey(
				name: "FK_GroupActivities_ActivityTypes_ActivityId",
				table: "GroupActivities",
				column: "ActivityId",
				principalTable: "ActivityTypes",
				principalColumn: "ActivityId",
				onDelete: ReferentialAction.Restrict);

			migrationBuilder.AddForeignKey(
				name: "FK_GroupActivities_Groups_GroupId",
				table: "GroupActivities",
				column: "GroupId",
				principalTable: "Groups",
				principalColumn: "GroupId",
				onDelete: ReferentialAction.Restrict);
		}
	}
}
