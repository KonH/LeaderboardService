using System.Collections.Generic;
using System.Collections.Concurrent;
using LeaderboardService.Models;

namespace LeaderboardService.Repositories
{
	public class InMemoryGameRepository : IGameRepository
	{
		private static ConcurrentDictionary<string, Game> _games =
			new ConcurrentDictionary<string, Game>();

		public InMemoryGameRepository()
		{
		}

		public IEnumerable<Game> GetAll()
		{
			return _games.Values;
		}

		public void Add(Game item)
		{
			_games[item.Name] = item;
		}

		public Game Find(string name)
		{
			Game item;
			_games.TryGetValue(name, out item);
			return item;
		}

		public Game Remove(string name)
		{
			Game item;
			_games.TryRemove(name, out item);
			return item;
		}

		public void Update(Game item)
		{
			_games[item.Name] = item;
		}
	}
}