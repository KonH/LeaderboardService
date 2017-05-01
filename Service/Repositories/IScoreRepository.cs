using System.Collections.Generic;
using LeaderboardService.Models;

namespace LeaderboardService.Repositories
{
	public interface IScoreRepository
	{
		void Add(ScoreItem item);
		IEnumerable<ScoreItem> GetTop(int max, string game = null, string param = null, string version = null);
		IEnumerable<ScoreItem> GetHistory(string game = null, string param = null, string version = null, string user = null);
		ScoreItem Find(string key);
		ScoreItem Remove(string key);
		void Update(ScoreItem item);
	}
}