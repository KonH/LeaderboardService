namespace LeaderboardService.Models
{
	public class ScoreItem
	{
		public string Key { get; set; }
		public string Game { get; set; }
		public string Version { get; set; }
		public string Param { get; set; }
		public int Score { get; set; }
	}
}