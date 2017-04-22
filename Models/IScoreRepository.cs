using System.Collections.Generic;

namespace LeaderboardService.Models
{
	public interface IScoreRepository
	{
		void Add(ScoreItem item);
		IEnumerable<ScoreItem> GetAll();
		ScoreItem Find(string key);
		ScoreItem Remove(string key);
		void Update(ScoreItem item);
	}
}