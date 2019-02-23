using SocialApp.Models;
using Microsoft.EntityFrameworkCore;

namespace SocialApp.Data
{
	public class GoingOutContext : DbContext
	{
		// Your context has been configured to use a 'GoingOutModel' connection string from your application's 
		// configuration file (App.config or Web.config). By default, this connection string targets the 
		// 'GoingOut.Data.GoingOutModel' database on your LocalDb instance. 
		// 
		// If you wish to target a different database and/or database provider, modify the 'GoingOutModel' 
		// connection string in the application configuration file.
		public GoingOutContext(DbContextOptions<GoingOutContext> options)
			: base(options)
		{ }

		public DbSet<User> Users { get; set; }
		public DbSet<Group> Groups { get; set; }
		public DbSet<GroupUser> GroupUsers { get; set; }
        public DbSet<GroupRole> GroupRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			ConfigureGroupTable(modelBuilder);
			ConfigureGroupRoleTable(modelBuilder);
			ConfigureGroupUserTable(modelBuilder);
			ConfigureUserTable(modelBuilder);
		}

		private void ConfigureGroupTable(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Group>()
				.HasKey(g => g.GroupId);

			modelBuilder.Entity<Group>()
				.Property(g => g.GroupName)
				.IsRequired();

        }
        private void ConfigureGroupRoleTable(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<GroupRole>()
                .HasKey(gr => gr.RoleId);

            modelBuilder.Entity<GroupRole>()
                .HasMany(gr => gr.GroupUsers)
                .WithOne(gu => gu.Role)
                .HasForeignKey(gr => gr.RoleId);

            modelBuilder.Entity<GroupRole>()
                .Property(gr => gr.RoleName)
                .IsRequired();
        }


        private void ConfigureGroupUserTable(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<GroupUser>()
				.HasKey(gu => new { gu.GroupId, gu.UserId });

			modelBuilder.Entity<GroupUser>()
				.HasOne(gu => gu.Group)
				.WithMany(g => g.GroupUsers)
				.HasForeignKey(gu => gu.GroupId);
			modelBuilder.Entity<GroupUser>()
				.HasOne(gu => gu.User)
				.WithMany(u => u.GroupUsers)
				.HasForeignKey(gu => gu.UserId);
		}

		private void ConfigureUserTable(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<User>()
				.HasKey(u => u.UserId);

			modelBuilder.Entity<User>()
				.Property(u => u.UserName)
				.IsRequired();

		}

		// Add a DbSet for each entity type that you want to include in your model. For more information 
		// on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

		// public virtual DbSet<MyEntity> MyEntities { get; set; }
	}

}