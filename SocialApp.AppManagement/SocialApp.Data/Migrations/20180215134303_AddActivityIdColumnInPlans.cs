using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialApp.Data.Migrations
{
	public partial class AddActivityIdColumnInPlans : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AddColumn<int>(
				name: "ActivityId",
				table: "Plans",
				nullable: false,
				defaultValue: 0);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn(
				name: "ActivityId",
				table: "Plans");
		}
	}
}
