using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialApp.Data.Migrations
{
	public partial class locationNullable : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AlterColumn<string>(
				name: "UserName",
				table: "Users",
				maxLength: 30,
				nullable: false,
				oldClrType: typeof(string));

			migrationBuilder.AlterColumn<string>(
				name: "Location",
				table: "Plans",
				maxLength: 100,
				nullable: true,
				oldClrType: typeof(string));

			migrationBuilder.AlterColumn<string>(
				name: "RoleName",
				table: "PlanRoles",
				maxLength: 20,
				nullable: false,
				oldClrType: typeof(string));

			migrationBuilder.AlterColumn<string>(
				name: "GroupName",
				table: "Groups",
				maxLength: 25,
				nullable: false,
				oldClrType: typeof(string));

			migrationBuilder.AlterColumn<string>(
				name: "RoleName",
				table: "GroupRoles",
				maxLength: 20,
				nullable: false,
				oldClrType: typeof(string));

			migrationBuilder.AlterColumn<string>(
				name: "ActivityName",
				table: "ActivityTypes",
				maxLength: 25,
				nullable: false,
				oldClrType: typeof(string));
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AlterColumn<string>(
				name: "UserName",
				table: "Users",
				nullable: false,
				oldClrType: typeof(string),
				oldMaxLength: 30);

			migrationBuilder.AlterColumn<string>(
				name: "Location",
				table: "Plans",
				nullable: false,
				oldClrType: typeof(string),
				oldMaxLength: 100,
				oldNullable: true);

			migrationBuilder.AlterColumn<string>(
				name: "RoleName",
				table: "PlanRoles",
				nullable: false,
				oldClrType: typeof(string),
				oldMaxLength: 20);

			migrationBuilder.AlterColumn<string>(
				name: "GroupName",
				table: "Groups",
				nullable: false,
				oldClrType: typeof(string),
				oldMaxLength: 25);

			migrationBuilder.AlterColumn<string>(
				name: "RoleName",
				table: "GroupRoles",
				nullable: false,
				oldClrType: typeof(string),
				oldMaxLength: 20);

			migrationBuilder.AlterColumn<string>(
				name: "ActivityName",
				table: "ActivityTypes",
				nullable: false,
				oldClrType: typeof(string),
				oldMaxLength: 25);
		}
	}
}
