using System.Collections.Generic;
using LeaderboardService.Models;

namespace LeaderboardService.Repositories
{
	public interface IScoreRepository
	{
		void Add(ScoreItem item);
		IEnumerable<ScoreItem> GetAll(int max, string game = null, string param = null, string version = null);
		ScoreItem Find(string key);
		ScoreItem Remove(string key);
		void Update(ScoreItem item);
	}
}