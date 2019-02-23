using SocialApp.Models;
using System;

namespace SocialApp.Data.DAL
{
	public interface IUnitOfWork : IDisposable
	{
		IGenericRepository<Group> GroupRepository { get; }
		IGenericRepository<GroupUser> GroupUserRepository { get; }
		IGenericRepository<User> UserRepository { get; }
		void Save();
	}
}