using System.Collections.Generic;
using LeaderboardService.Models;

namespace LeaderboardService.Repositories
{
	public interface IUserRepository
	{
		void Add(User item);
		IEnumerable<User> GetAll();
		User Find(string name);
		User Remove(string name);
		void Update(User item);
	}
}