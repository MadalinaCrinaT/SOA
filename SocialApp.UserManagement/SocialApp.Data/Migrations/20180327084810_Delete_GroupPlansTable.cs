using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialApp.Data.Migrations
{
	public partial class Delete_GroupPlansTable : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "GroupPlans");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "GroupPlans",
				columns: table => new
				{
					GroupId = table.Column<int>(nullable: false),
					PlanId = table.Column<int>(nullable: false),
					Visible = table.Column<int>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_GroupPlans", x => new { x.GroupId, x.PlanId });
					table.ForeignKey(
						name: "FK_GroupPlans_Groups_GroupId",
						column: x => x.GroupId,
						principalTable: "Groups",
						principalColumn: "GroupId",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_GroupPlans_Plans_PlanId",
						column: x => x.PlanId,
						principalTable: "Plans",
						principalColumn: "PlanId",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateIndex(
				name: "IX_GroupPlans_PlanId",
				table: "GroupPlans",
				column: "PlanId");
		}
	}
}
