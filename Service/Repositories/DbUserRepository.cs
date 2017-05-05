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
				var users = _context.Users.ToList();
				foreach ( var user in users )
				{
					user.Roles = FindRoles(user.Name);
				}
				return users;
			}
		}

		public void Add(User item)
		{
			lock ( _context )
			{
				_context.Users.Add(item);
				AddRoles(item.Name, item.Roles);
				_context.SaveChanges();
			}
		}

		public User Find(string name)
		{
			lock ( _context )
			{
				var user = _context.Users.Find(name);
				if ( user != null )
				{
					user.Roles = FindRoles(user.Name);
				}
				return user;
			}
		}

		public User Remove(string name)
		{
			lock ( _context )
			{
				var user = Find(name);
				if ( user != null )
				{
					RemoveRoles(user.Name);
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
				if ( user != null )
				{
					user.Password = item.Password;
					RemoveRoles(user.Name);
					user.Roles = item.Roles;
					AddRoles(user.Name, user.Roles);
					_context.Users.Update(user);
					_context.SaveChanges();
				}
			}
		}

		List<UserRole> FindRoles(string userName)
		{
			return _context.Roles.Where(r => r.User == userName).ToList();
		}

		void AddRoles(string userName, List<UserRole> roles)
		{
			if ( roles != null ) 
			{
				foreach ( var role in roles )
				{
					role.User = userName;
					if ( role.Game == null )
					{
						role.Game = string.Empty;
					}
					_context.Roles.Add(role);
				}
			}
		}

		void RemoveRoles(string userName)
		{
			_context.Roles.RemoveRange(FindRoles(userName));
		}
	}
}