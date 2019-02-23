using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialApp.Data.Migrations
{
	public partial class ChangeLocationToPlan : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn(
				name: "Location",
				table: "ActivityTypes");

			migrationBuilder.AddColumn<string>(
				name: "Location",
				table: "Plans",
				nullable: false,
				defaultValue: "");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn(
				name: "Location",
				table: "Plans");

			migrationBuilder.AddColumn<string>(
				name: "Location",
				table: "ActivityTypes",
				nullable: false,
				defaultValue: "");
		}
	}
}
