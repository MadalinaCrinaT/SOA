using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialApp.Data.Migrations
{
	public partial class GroupActivitiesTableAdded : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "GroupActivities",
				columns: table => new
				{
					GroupId = table.Column<int>(nullable: false),
					ActivityId = table.Column<int>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_GroupActivities", x => new { x.GroupId, x.ActivityId });
					table.ForeignKey(
						name: "FK_GroupActivities_ActivityTypes_ActivityId",
						column: x => x.ActivityId,
						principalTable: "ActivityTypes",
						principalColumn: "ActivityId",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_GroupActivities_Groups_GroupId",
						column: x => x.GroupId,
						principalTable: "Groups",
						principalColumn: "GroupId",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateIndex(
				name: "IX_GroupActivities_ActivityId",
				table: "GroupActivities",
				column: "ActivityId");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "GroupActivities");
		}
	}
}
