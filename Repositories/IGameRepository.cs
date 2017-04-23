using System.Collections.Generic;
using LeaderboardService.Models;

namespace LeaderboardService.Repositories
{
	public interface IGameRepository
	{
		void Add(Game item);
		IEnumerable<Game> GetAll();
		Game Find(string name);
		Game Remove(string name);
		void Update(Game item);
	}
}