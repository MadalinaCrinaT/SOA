using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialApp.Data.Migrations
{
	public partial class NullableActivityIdInPlans : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_Plans_ActivityTypes_ActivityId",
				table: "Plans");

			migrationBuilder.AlterColumn<int>(
				name: "ActivityId",
				table: "Plans",
				nullable: true,
				oldClrType: typeof(int));

			migrationBuilder.AddForeignKey(
				name: "FK_Plans_ActivityTypes_ActivityId",
				table: "Plans",
				column: "ActivityId",
				principalTable: "ActivityTypes",
				principalColumn: "ActivityId",
				onDelete: ReferentialAction.Restrict);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_Plans_ActivityTypes_ActivityId",
				table: "Plans");

			migrationBuilder.AlterColumn<int>(
				name: "ActivityId",
				table: "Plans",
				nullable: false,
				oldClrType: typeof(int),
				oldNullable: true);

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
