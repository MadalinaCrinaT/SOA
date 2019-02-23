using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace SocialApp.Data.Migrations
{
	public partial class Initial : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "GroupRoles",
				columns: table => new
				{
					RoleId = table.Column<int>(nullable: false)
						.Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
					RoleName = table.Column<string>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_GroupRoles", x => x.RoleId);
				});

			migrationBuilder.CreateTable(
				name: "Groups",
				columns: table => new
				{
					GroupId = table.Column<int>(nullable: false)
						.Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
					GroupName = table.Column<string>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Groups", x => x.GroupId);
				});

			migrationBuilder.CreateTable(
				name: "PlanRoles",
				columns: table => new
				{
					RoleId = table.Column<int>(nullable: false)
						.Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
					RoleName = table.Column<string>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_PlanRoles", x => x.RoleId);
				});

			migrationBuilder.CreateTable(
				name: "Users",
				columns: table => new
				{
					UserId = table.Column<int>(nullable: false)
						.Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
					UserName = table.Column<string>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Users", x => x.UserId);
				});

			migrationBuilder.CreateTable(
				name: "ActivityTypes",
				columns: table => new
				{
					ActivityId = table.Column<int>(nullable: false)
						.Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
					ActivityName = table.Column<string>(nullable: false),
					GroupId = table.Column<int>(nullable: false),
					Location = table.Column<string>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_ActivityTypes", x => x.ActivityId);
					table.ForeignKey(
						name: "FK_ActivityTypes_Groups_GroupId",
						column: x => x.GroupId,
						principalTable: "Groups",
						principalColumn: "GroupId",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "GroupUsers",
				columns: table => new
				{
					GroupId = table.Column<int>(nullable: false),
					UserId = table.Column<int>(nullable: false),
					RoleId = table.Column<int>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_GroupUsers", x => new { x.GroupId, x.UserId });
					table.ForeignKey(
						name: "FK_GroupUsers_Groups_GroupId",
						column: x => x.GroupId,
						principalTable: "Groups",
						principalColumn: "GroupId",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_GroupUsers_GroupRoles_RoleId",
						column: x => x.RoleId,
						principalTable: "GroupRoles",
						principalColumn: "RoleId",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_GroupUsers_Users_UserId",
						column: x => x.UserId,
						principalTable: "Users",
						principalColumn: "UserId",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "Plans",
				columns: table => new
				{
					PlanId = table.Column<int>(nullable: false)
						.Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
					ActivityId = table.Column<int>(nullable: false),
					EndDate = table.Column<DateTime>(nullable: false),
					StartDate = table.Column<DateTime>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Plans", x => x.PlanId);
					table.ForeignKey(
						name: "FK_Plans_ActivityTypes_ActivityId",
						column: x => x.ActivityId,
						principalTable: "ActivityTypes",
						principalColumn: "ActivityId",
						onDelete: ReferentialAction.Cascade);
				});

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

			migrationBuilder.CreateTable(
				name: "UserPlans",
				columns: table => new
				{
					PlanId = table.Column<int>(nullable: false),
					UserId = table.Column<int>(nullable: false),
					RoleId = table.Column<int>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_UserPlans", x => new { x.PlanId, x.UserId });
					table.ForeignKey(
						name: "FK_UserPlans_Plans_PlanId",
						column: x => x.PlanId,
						principalTable: "Plans",
						principalColumn: "PlanId",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_UserPlans_PlanRoles_RoleId",
						column: x => x.RoleId,
						principalTable: "PlanRoles",
						principalColumn: "RoleId",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_UserPlans_Users_UserId",
						column: x => x.UserId,
						principalTable: "Users",
						principalColumn: "UserId",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateIndex(
				name: "IX_ActivityTypes_GroupId",
				table: "ActivityTypes",
				column: "GroupId");

			migrationBuilder.CreateIndex(
				name: "IX_GroupPlans_PlanId",
				table: "GroupPlans",
				column: "PlanId");

			migrationBuilder.CreateIndex(
				name: "IX_GroupUsers_RoleId",
				table: "GroupUsers",
				column: "RoleId");

			migrationBuilder.CreateIndex(
				name: "IX_GroupUsers_UserId",
				table: "GroupUsers",
				column: "UserId");

			migrationBuilder.CreateIndex(
				name: "IX_Plans_ActivityId",
				table: "Plans",
				column: "ActivityId");

			migrationBuilder.CreateIndex(
				name: "IX_UserPlans_RoleId",
				table: "UserPlans",
				column: "RoleId");

			migrationBuilder.CreateIndex(
				name: "IX_UserPlans_UserId",
				table: "UserPlans",
				column: "UserId");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "GroupPlans");

			migrationBuilder.DropTable(
				name: "GroupUsers");

			migrationBuilder.DropTable(
				name: "UserPlans");

			migrationBuilder.DropTable(
				name: "GroupRoles");

			migrationBuilder.DropTable(
				name: "Plans");

			migrationBuilder.DropTable(
				name: "PlanRoles");

			migrationBuilder.DropTable(
				name: "Users");

			migrationBuilder.DropTable(
				name: "ActivityTypes");

			migrationBuilder.DropTable(
				name: "Groups");
		}
	}
}
