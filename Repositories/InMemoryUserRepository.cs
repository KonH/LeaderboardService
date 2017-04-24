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
				Name = "User",
				Roles = new List<User.Role>(new User.Role[] {
					new User.Role() {
						Permissions = User.Permission.PostScores,
						Game = "Game"
					}
				}),
				// User:password1
				AuthHash = "VXNlcjpwYXNzd29yZDE="
			});
			Add(new User {
				Name = "Admin",
				Roles = new List<User.Role>(new User.Role[] {
					new User.Role() { 
						Permissions = 
							User.Permission.UpdateScores |
							User.Permission.ReadGames | 
							User.Permission.PostGames |
							User.Permission.UpdateGames |
							User.Permission.ReadUsers |
							User.Permission.PostUsers |
							User.Permission.UpdateUsers
					}
				}),
				// Admin:password2
				AuthHash = "QWRtaW46cGFzc3dvcmQy"
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