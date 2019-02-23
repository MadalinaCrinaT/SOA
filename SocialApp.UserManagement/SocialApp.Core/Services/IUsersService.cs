using SocialApp.Models;

namespace SocialApp.Core.Services
{
	public interface IUsersServices
	{
		User GetById(int id);
        User Get(string userName);
        User CreateUser(User user);
		User DeleteUser(int userId);
	}
}
