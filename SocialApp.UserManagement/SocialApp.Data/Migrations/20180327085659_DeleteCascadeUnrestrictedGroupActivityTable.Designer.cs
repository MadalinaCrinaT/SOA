﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace SocialApp.Data.Migrations
{
	[DbContext(typeof(GoingOutContext))]
	[Migration("20180327085659_DeleteCascadeUnrestrictedGroupActivityTable")]
	partial class DeleteCascadeUnrestrictedGroupActivityTable
	{
		protected override void BuildTargetModel(ModelBuilder modelBuilder)
		{
#pragma warning disable 612, 618
			modelBuilder
				.HasAnnotation("ProductVersion", "2.0.1-rtm-125")
				.HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

			modelBuilder.Entity("GoingOut.Core.Data.ActivityType", b =>
				{
					b.Property<int>("ActivityId")
						.ValueGeneratedOnAdd();

					b.Property<string>("ActivityName")
						.IsRequired()
						.HasMaxLength(25);

					b.HasKey("ActivityId");

					b.ToTable("ActivityTypes");
				});

			modelBuilder.Entity("GoingOut.Core.Data.Group", b =>
				{
					b.Property<int>("GroupId")
						.ValueGeneratedOnAdd();

					b.Property<string>("GroupName")
						.IsRequired()
						.HasMaxLength(25);

					b.HasKey("GroupId");

					b.ToTable("Groups");
				});

			modelBuilder.Entity("GoingOut.Core.Data.GroupActivity", b =>
				{
					b.Property<int>("GroupId");

					b.Property<int>("ActivityId");

					b.HasKey("GroupId", "ActivityId");

					b.HasIndex("ActivityId");

					b.ToTable("GroupActivities");
				});

			modelBuilder.Entity("GoingOut.Core.Data.GroupRole", b =>
				{
					b.Property<int>("RoleId")
						.ValueGeneratedOnAdd();

					b.Property<string>("RoleName")
						.IsRequired()
						.HasMaxLength(20);

					b.HasKey("RoleId");

					b.ToTable("GroupRoles");
				});

			modelBuilder.Entity("GoingOut.Core.Data.GroupUser", b =>
				{
					b.Property<int>("GroupId");

					b.Property<int>("UserId");

					b.Property<int>("RoleId");

					b.HasKey("GroupId", "UserId");

					b.HasIndex("RoleId");

					b.HasIndex("UserId");

					b.ToTable("GroupUsers");
				});

			modelBuilder.Entity("GoingOut.Core.Data.Plan", b =>
				{
					b.Property<int>("PlanId")
						.ValueGeneratedOnAdd();

					b.Property<int?>("ActivityId");

					b.Property<DateTime>("EndDate");

					b.Property<int>("GroupId");

					b.Property<string>("Location")
						.HasMaxLength(100);

					b.Property<DateTime>("StartDate");

					b.HasKey("PlanId");

					b.HasIndex("ActivityId");

					b.HasIndex("GroupId");

					b.ToTable("Plans");
				});

			modelBuilder.Entity("GoingOut.Core.Data.PlanRole", b =>
				{
					b.Property<int>("RoleId")
						.ValueGeneratedOnAdd();

					b.Property<string>("RoleName")
						.IsRequired()
						.HasMaxLength(20);

					b.HasKey("RoleId");

					b.ToTable("PlanRoles");
				});

			modelBuilder.Entity("GoingOut.Core.Data.User", b =>
				{
					b.Property<int>("UserId")
						.ValueGeneratedOnAdd();

					b.Property<string>("UserName")
						.IsRequired()
						.HasMaxLength(30);

					b.HasKey("UserId");

					b.ToTable("Users");
				});

			modelBuilder.Entity("GoingOut.Core.Data.UserPlan", b =>
				{
					b.Property<int>("PlanId");

					b.Property<int>("UserId");

					b.Property<int>("RoleId");

					b.HasKey("PlanId", "UserId");

					b.HasIndex("RoleId");

					b.HasIndex("UserId");

					b.ToTable("UserPlans");
				});

			modelBuilder.Entity("GoingOut.Core.Data.GroupActivity", b =>
				{
					b.HasOne("GoingOut.Core.Data.ActivityType", "Activity")
						.WithMany("GroupActivities")
						.HasForeignKey("ActivityId")
						.OnDelete(DeleteBehavior.Cascade);

					b.HasOne("GoingOut.Core.Data.Group", "Group")
						.WithMany("GroupActivities")
						.HasForeignKey("GroupId")
						.OnDelete(DeleteBehavior.Cascade);
				});

			modelBuilder.Entity("GoingOut.Core.Data.GroupUser", b =>
				{
					b.HasOne("GoingOut.Core.Data.Group", "Group")
						.WithMany("GroupUsers")
						.HasForeignKey("GroupId")
						.OnDelete(DeleteBehavior.Cascade);

					b.HasOne("GoingOut.Core.Data.GroupRole", "Role")
						.WithMany("GroupUsers")
						.HasForeignKey("RoleId")
						.OnDelete(DeleteBehavior.Cascade);

					b.HasOne("GoingOut.Core.Data.User", "User")
						.WithMany("GroupUsers")
						.HasForeignKey("UserId")
						.OnDelete(DeleteBehavior.Cascade);
				});

			modelBuilder.Entity("GoingOut.Core.Data.Plan", b =>
				{
					b.HasOne("GoingOut.Core.Data.ActivityType", "Activity")
						.WithMany("Plans")
						.HasForeignKey("ActivityId");

					b.HasOne("GoingOut.Core.Data.Group", "Group")
						.WithMany("Plans")
						.HasForeignKey("GroupId")
						.OnDelete(DeleteBehavior.Cascade);
				});

			modelBuilder.Entity("GoingOut.Core.Data.UserPlan", b =>
				{
					b.HasOne("GoingOut.Core.Data.Plan", "Plan")
						.WithMany("UserPlans")
						.HasForeignKey("PlanId")
						.OnDelete(DeleteBehavior.Cascade);

					b.HasOne("GoingOut.Core.Data.PlanRole", "Role")
						.WithMany("UserPlans")
						.HasForeignKey("RoleId")
						.OnDelete(DeleteBehavior.Cascade);

					b.HasOne("GoingOut.Core.Data.User", "User")
						.WithMany("UserPlans")
						.HasForeignKey("UserId")
						.OnDelete(DeleteBehavior.Cascade);
				});
#pragma warning restore 612, 618
		}
	}
}
