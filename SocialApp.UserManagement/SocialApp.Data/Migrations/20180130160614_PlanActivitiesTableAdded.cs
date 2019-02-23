using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialApp.Data.Migrations
{
	public partial class PlanActivitiesTableAdded : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_Plans_ActivityTypes_ActivityId",
				table: "Plans");

			migrationBuilder.DropIndex(
				name: "IX_Plans_ActivityId",
				table: "Plans");

			migrationBuilder.DropColumn(
				name: "ActivityId",
				table: "Plans");

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

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "PlanActivities");

			migrationBuilder.AddColumn<int>(
				name: "ActivityId",
				table: "Plans",
				nullable: false,
				defaultValue: 0);

			migrationBuilder.CreateIndex(
				name: "IX_Plans_ActivityId",
				table: "Plans",
				column: "ActivityId");

			migrationBuilder.AddForeignKey(
				name: "FK_Plans_ActivityTypes_ActivityId",
				table: "Plans",
				column: "ActivityId",
				principalTable: "ActivityTypes",
				principalColumn: "ActivityId",
				onDelete: ReferentialAction.Cascade);
		}
	}
}
