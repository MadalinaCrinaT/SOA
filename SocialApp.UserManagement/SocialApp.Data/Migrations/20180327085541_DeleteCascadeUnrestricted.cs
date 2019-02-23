using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialApp.Data.Migrations
{
	public partial class DeleteCascadeUnrestricted : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_Plans_Groups_GroupId",
				table: "Plans");

			migrationBuilder.AddForeignKey(
				name: "FK_Plans_Groups_GroupId",
				table: "Plans",
				column: "GroupId",
				principalTable: "Groups",
				principalColumn: "GroupId",
				onDelete: ReferentialAction.Cascade);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_Plans_Groups_GroupId",
				table: "Plans");

			migrationBuilder.AddForeignKey(
				name: "FK_Plans_Groups_GroupId",
				table: "Plans",
				column: "GroupId",
				principalTable: "Groups",
				principalColumn: "GroupId",
				onDelete: ReferentialAction.Restrict);
		}
	}
}
