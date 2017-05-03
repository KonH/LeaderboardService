using Newtonsoft.Json;

namespace LeaderboardService.Models
{
    public class UserRole {
		[JsonIgnore]
		public string ID { get; set; }
		public UserPermission Permissions { get; set; }
		public string Game { get; set; }
	}
}