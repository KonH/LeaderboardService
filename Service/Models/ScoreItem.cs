using System;
using Newtonsoft.Json;

namespace LeaderboardService.Models
{
	public class ScoreItem
	{
		[JsonIgnore]
		public string Key { get; set; }
		public string Game { get; set; }
		public string Version { get; set; }
		public string Param { get; set; }
		public int Score { get; set; }
		public string User { get; set; }
		public DateTime Date { get; set; }
	}
}