using System.Collections.Generic;
using LeaderboardService.Models;
using LeaderboardService.Data;

namespace LeaderboardService.Repositories
{
	public class DbUserRepository : IUserRepository
	{
		ServiceContext _context;

		public DbUserRepository(ServiceContext context)
		{
			_context = context;
		}

		public IEnumerable<User> GetAll()
		{
			return _context.Users;
		}

		public void Add(User item)
		{
			_context.Users.Add(item);
			_context.SaveChanges();
		}

		public User Find(string name)
		{
			return _context.Users.Find(name);
		}

		public User Remove(string name)
		{
			var user = Find(name);
			if ( user != null )
			{
				_context.Users.Remove(user);
				_context.SaveChanges();
			}
			return user;
		}

		public void Update(User item)
		{
			var user = _context.Users.Find(item.Name);
			if ( user != null ) {
				user.Password = item.Password;
				user.Roles = item.Roles;
				_context.Users.Update(user);
				_context.SaveChanges();
			}
		}
	}
}