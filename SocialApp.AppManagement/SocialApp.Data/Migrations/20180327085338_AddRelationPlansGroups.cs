using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialApp.Data.Migrations
{
	public partial class AddRelationPlansGroups : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateIndex(
				name: "IX_Plans_GroupId",
				table: "Plans",
				column: "GroupId");

			migrationBuilder.AddForeignKey(
				name: "FK_Plans_Groups_GroupId",
				table: "Plans",
				column: "GroupId",
				principalTable: "Groups",
				principalColumn: "GroupId",
				onDelete: ReferentialAction.Restrict);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_Plans_Groups_GroupId",
				table: "Plans");

			migrationBuilder.DropIndex(
				name: "IX_Plans_GroupId",
				table: "Plans");
		}
	}
}
