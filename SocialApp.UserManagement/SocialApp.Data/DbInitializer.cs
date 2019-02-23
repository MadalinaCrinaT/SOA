using SocialApp.Models;
using System;
using System.Linq;

namespace SocialApp.Data
{
    public static class DbInitializer
    {
        public static void Initialize(GoingOutContext context)
        {
            context.Database.EnsureCreated();

            // Look for any user.
            if (context.Users.Any())
            {
                return;   // DB has been seeded
            }
            var users = new User[]
            {
            new User { UserName = "Mada" },
            new User { UserName = "Crina" },
            new User { UserName = "Cristi" },
            new User { UserName = "Marius" },
            new User { UserName = "Anda" },
            new User { UserName = "Andrei" },
            new User { UserName = "George" },
            new User { UserName = "Nicu" }
            };
            foreach (User u in users)
            {
                context.Users.Add(u);
            }
            context.SaveChanges();

            var groups = new Group[]
            {
            new Group { GroupName = "Office" },
            new Group { GroupName = "Friends" }
            };
            foreach (Group g in groups)
            {
                context.Groups.Add(g);
            }
            context.SaveChanges();

            var groupRoles = new GroupRole[]
            {
            new GroupRole{RoleName = "Creator" },
            new GroupRole{RoleName = "Admin" },
            new GroupRole{RoleName = "Member" }
            };
            foreach (GroupRole gr in groupRoles)
            {
                context.GroupRoles.Add(gr);
            }
            context.SaveChanges();

            var groupUsers = new GroupUser[]
            {
            new GroupUser{GroupId = 1,UserId = 1,RoleId=1 },
            new GroupUser{GroupId = 1,UserId = 2,RoleId=3 },
            new GroupUser{GroupId = 1,UserId = 3,RoleId=2 },
            new GroupUser{GroupId = 1,UserId = 4,RoleId=3 },
            new GroupUser{GroupId = 1,UserId = 5,RoleId=3 },
            new GroupUser{GroupId = 1,UserId = 6,RoleId=2 },
            new GroupUser{GroupId = 2,UserId = 3,RoleId=3 },
            new GroupUser{GroupId = 2,UserId = 4,RoleId=3 },
            new GroupUser{GroupId = 2,UserId = 6,RoleId=3 },
            new GroupUser{GroupId = 2,UserId = 7,RoleId=1 },
            new GroupUser{GroupId = 2,UserId = 8,RoleId=2 }
            };
            foreach (GroupUser gu in groupUsers)
            {
                context.GroupUsers.Add(gu);
            }
            context.SaveChanges();
        }
    }
}
