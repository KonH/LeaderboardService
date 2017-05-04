using System.Linq;
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
			lock ( _context )
			{
				return _context.Games.ToList();
			}
		}

		public void Add(Game item)
		{
			lock ( _context )
			{
				_context.Games.Add(item);
				_context.SaveChanges();
			}
		}

		public Game Find(string name)
		{
			lock ( _context )
			{
				return _context.Games.Find(name);
			}
		}

		public Game Remove(string name)
		{
			lock ( _context )
			{
				Game item = _context.Games.Find(name);
				if ( item != null )
				{
					_context.Games.Remove(item);
					_context.SaveChanges();
				}
				return item;
			}
		}

		public void Update(Game item)
		{
			lock ( _context )
			{
				var game = _context.Games.Find(item.Name);
				if ( game != null )
				{
					_context.Games.Update(game);
					_context.SaveChanges();
				}
			}
		}
	}
}