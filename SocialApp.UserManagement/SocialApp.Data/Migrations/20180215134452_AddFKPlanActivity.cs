using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialApp.Data.Migrations
{
	public partial class AddFKPlanActivity : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
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

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_Plans_ActivityTypes_ActivityId",
				table: "Plans");

			migrationBuilder.DropIndex(
				name: "IX_Plans_ActivityId",
				table: "Plans");
		}
	}
}
