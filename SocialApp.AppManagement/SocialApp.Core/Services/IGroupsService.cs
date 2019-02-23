using SocialApp.Models;
using System.Collections.Generic;

namespace SocialApp.Core.Services
{
	public interface IGroupsServices
	{
		List<Group> Get();
		Group GetById(int groupId);
		List<User> GetGroupMembers(int groupId);
		Group CreateGroup(int userId, Group group);
		Group DeleteGroup(int userId, int groupId);
		Group UpdateGroupName(int groupId, string groupName);
		List<Group> GetGroups(int userId);
        User GetGroupOwner(int groupId);
        void Join(int userId, int groupId);
	}
}
