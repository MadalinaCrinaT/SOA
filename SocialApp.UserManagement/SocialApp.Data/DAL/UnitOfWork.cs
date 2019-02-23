using SocialApp.Models;
using System;

namespace SocialApp.Data.DAL
{
	public class UnitOfWork : IUnitOfWork, IDisposable
	{
		private readonly GoingOutContext _context;
		private readonly IGenericRepository<Group> _groupRepository;
		private readonly IGenericRepository<GroupUser> _groupUserRepository;
		private readonly IGenericRepository<User> _userRepository;

		public UnitOfWork(GoingOutContext context)
		{
			_context = context;
		}

		public IGenericRepository<Group> GroupRepository
		{
			get
			{
				return _groupRepository ?? new GenericRepository<Group>(_context);
			}
		}

		public IGenericRepository<GroupUser> GroupUserRepository
		{
			get
			{
				return _groupUserRepository ?? new GenericRepository<GroupUser>(_context);
			}
		}

		public IGenericRepository<User> UserRepository
		{
			get
			{
				return _userRepository ?? new GenericRepository<User>(_context);
			}
		}
        
		public void Save()
		{
			_context.SaveChanges();
		}

		private bool disposed = false;

		protected virtual void Dispose(bool disposing)
		{
			if (!disposed)
			{
				if (disposing)
				{
					_context.Dispose();
				}
			}
			disposed = true;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}