using System.Linq;
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
			lock ( _context )
			{
				return _context.Users.ToList();
			}
		}

		public void Add(User item)
		{
			lock ( _context )
			{
				_context.Users.Add(item);
				_context.SaveChanges();
			}
		}

		public User Find(string name)
		{
			lock ( _context )
			{
				return _context.Users.Find(name);
			}
		}

		public User Remove(string name)
		{
			lock ( _context )
			{
				var user = Find(name);
				if ( user != null )
				{
					_context.Users.Remove(user);
					_context.SaveChanges();
				}
				return user;
			}
		}

		public void Update(User item)
		{
			lock ( _context )
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
}