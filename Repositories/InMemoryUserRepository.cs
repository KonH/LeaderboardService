using System.Collections.Generic;
using System.Collections.Concurrent;
using LeaderboardService.Models;

namespace LeaderboardService.Repositories
{
	public class InMemoryUserRepository : IUserRepository
	{
		private static ConcurrentDictionary<string, User> _users =
			new ConcurrentDictionary<string, User>();

		public InMemoryUserRepository()
		{
			Add( new User {
				Name = "user",
				Password = "user",
				Roles = new List<UserRole>(new UserRole[] {
					new UserRole() {
						Permissions = UserPermission.PostScores | UserPermission.ReadScores,
						Game = "Game"
					}
				})
			});
			Add(new User {
				Name = "admin",
				Password = "admin",
				Roles = new List<UserRole>(new UserRole[] {
					new UserRole() { 
						Permissions = 
							UserPermission.UpdateScores |
							UserPermission.ReadGames | 
							UserPermission.PostGames |
							UserPermission.UpdateGames |
							UserPermission.ReadUsers |
							UserPermission.PostUsers |
							UserPermission.UpdateUsers
					}
				})
			});
		}

		public IEnumerable<User> GetAll()
		{
			return _users.Values;
		}

		public void Add(User item)
		{
			_users[item.Name] = item;
		}

		public User Find(string name)
		{
			User item;
			_users.TryGetValue(name, out item);
			return item;
		}

		public User Remove(string name)
		{
			User item;
			_users.TryRemove(name, out item);
			return item;
		}

		public void Update(User item)
		{
			_users[item.Name] = item;
		}
	}
}