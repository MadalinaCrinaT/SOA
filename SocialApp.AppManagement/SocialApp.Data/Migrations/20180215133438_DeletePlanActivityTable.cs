using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialApp.Data.Migrations
{
	public partial class DeletePlanActivityTable : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "PlanActivities");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "PlanActivities",
				columns: table => new
				{
					PlanId = table.Column<int>(nullable: false),
					ActivityId = table.Column<int>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_PlanActivities", x => new { x.PlanId, x.ActivityId });
					table.ForeignKey(
						name: "FK_PlanActivities_ActivityTypes_ActivityId",
						column: x => x.ActivityId,
						principalTable: "ActivityTypes",
						principalColumn: "ActivityId",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_PlanActivities_Plans_PlanId",
						column: x => x.PlanId,
						principalTable: "Plans",
						principalColumn: "PlanId",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateIndex(
				name: "IX_PlanActivities_ActivityId",
				table: "PlanActivities",
				column: "ActivityId");
		}
	}
}
