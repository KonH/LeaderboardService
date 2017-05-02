using System.Collections.Generic;
using LeaderboardService.Models;
using LeaderboardService.Data;

namespace LeaderboardService.Repositories
{
	public class DbGameRepository : IGameRepository
	{
		ServiceContext _context;

		public DbGameRepository(ServiceContext context)
		{
			_context = context;
		}

		public IEnumerable<Game> GetAll() 
		{
			return _context.Games;
		}

		public void Add(Game item)
		{
			_context.Games.Add(item);
			_context.SaveChanges();
		}

		public Game Find(string name)
		{
			return _context.Games.Find(name);
		}

		public Game Remove(string name)
		{
			Game item = _context.Games.Find(name);
			if ( item != null )
			{
				_context.Games.Remove(item);
				_context.SaveChanges();
			}
			return item;
		}

		public void Update(Game item)
		{
			_context.Games.Update(item);
			_context.SaveChanges();
		}
	}
}