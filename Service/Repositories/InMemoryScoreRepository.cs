using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.Concurrent;
using LeaderboardService.Models;

namespace LeaderboardService.Repositories
{
	public class InMemoryScoreRepository : IScoreRepository
	{
		private static ConcurrentDictionary<string, ScoreItem> _scores =
			new ConcurrentDictionary<string, ScoreItem>();

		public InMemoryScoreRepository()
		{
		}

		public IEnumerable<ScoreItem> GetTop(int max, string game = null, string param = null, string version = null)
		{
			var topList = new List<ScoreItem>();
			var users = new List<string>();
			var searchList = 
				_scores.Values.
				Where(item => IsWantedItem(item, game, param, version, null)).
				OrderByDescending(item => item.Score);
			foreach ( var item in searchList )
			{
				if ( topList.Count >= max )
				{
					break;
				}
				var user = item.User;
				if ( users.Contains(user) )
				{
					continue;
				} else {
					topList.Add(item);
					users.Add(user);
				}
			}
			return topList;
		}

		public IEnumerable<ScoreItem> GetHistory(string game = null, string param = null, string version = null, string user = null)
		{
			return _scores.Values.
				Where(item => IsWantedItem(item, game, param, version, user)).
				OrderBy(item => item.Date);
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
			item.Key = Guid.NewGuid().ToString();
			_scores[item.Key] = item;
		}

		public ScoreItem Find(string key)
		{
			ScoreItem item;
			_scores.TryGetValue(key, out item);
			return item;
		}

		public ScoreItem Remove(string key)
		{
			ScoreItem item;
			_scores.TryRemove(key, out item);
			return item;
		}

		public void Update(ScoreItem item)
		{
			_scores[item.Key] = item;
		}
	}
}