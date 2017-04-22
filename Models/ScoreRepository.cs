using System;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace LeaderboardService.Models
{
	public class ScoreRepository : IScoreRepository
	{
		private static ConcurrentDictionary<string, ScoreItem> _scores =
			new ConcurrentDictionary<string, ScoreItem>();

		public ScoreRepository()
		{
			Add(new ScoreItem { Score = 999 });
		}

		public IEnumerable<ScoreItem> GetAll()
		{
			return _scores.Values;
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