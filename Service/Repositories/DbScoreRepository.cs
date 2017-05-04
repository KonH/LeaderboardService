using System;
using System.Linq;
using System.Collections.Generic;
using LeaderboardService.Models;
using LeaderboardService.Data;

namespace LeaderboardService.Repositories
{
	public class DbScoreRepository : IScoreRepository
	{
		ServiceContext _context;

		public DbScoreRepository(ServiceContext context)
		{
			_context = context;
		}

		public IEnumerable<ScoreItem> GetTop(int max, string game = null, string param = null, string version = null)
		{
			lock ( _context )
			{
				var topList = new List<ScoreItem>();
				var users = new List<string>();
				var result = _context.Scores.
					Where(item => IsWantedItem(item, game, param, version, null)).
					OrderByDescending(item => item.Score);

				foreach ( var item in result )
				{
					if ( topList.Count >= max )
					{
						break;
					}
					var user = item.User;
					if ( users.Contains(user) )
					{
						continue;
					} else
					{
						topList.Add(item);
						users.Add(user);
					}
				}

				return topList.ToList();
			}
		}

		public IEnumerable<ScoreItem> GetHistory(string game = null, string param = null, string version = null, string user = null)
		{
			lock ( _context )
			{
				return _context.Scores.
					Where(item => IsWantedItem(item, game, param, version, user)).
					OrderBy(item => item.Date).ToList();
			}
		}

		bool IsWantedItem(ScoreItem item, string game, string param, string version, string user) 
		{
			return
				(string.IsNullOrEmpty(game) || (item.Game == game)) && 
				(string.IsNullOrEmpty(param) || (item.Param == param)) &&
				(string.IsNullOrEmpty(version) || (item.Version == version)) &&
				(string.IsNullOrEmpty(user) || (item.User == user));
		}

		public void Add(ScoreItem item)
		{
			lock ( _context )
			{
				item.Key = Guid.NewGuid().ToString();
				_context.Scores.Add(item);
				_context.SaveChanges();
			}
		}

		public ScoreItem Find(string key)
		{
			lock ( _context )
			{
				return _context.Scores.Find(key);
			}
		}

		public ScoreItem Remove(string key)
		{
			lock ( _context ) 
			{
				ScoreItem item = _context.Scores.Find(key);
				if ( item != null )
				{
					_context.Scores.Remove(item);
					_context.SaveChanges();
				}
				return item;
			}
		}

		public void Update(ScoreItem item)
		{
			lock ( _context ) 
			{
				ScoreItem score = _context.Scores.Find(item.Key);
				if ( score != null )
				{
					score.Date = item.Date;
					score.Game = item.Game;
					score.Param = item.Param;
					score.Score = item.Score;
					score.User = item.User;
					score.Version = item.Version;
					_context.SaveChanges();
				}
			}
		}
	}
}