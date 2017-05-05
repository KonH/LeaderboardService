using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace LeaderboardService.Models
{
    public class UserRole {
		[JsonIgnore]
		[Key]
		public string User { get; set; }
		[Key]
		public string Game { get; set; }
		public UserPermission Permissions { get; set; }
	}
}