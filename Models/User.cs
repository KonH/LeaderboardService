using System.Collections.Generic;

namespace LeaderboardService.Models
{
    public class User
    {
		public enum Permission {
			SendScores,
			ManageScores,
			ManageUsers,
			ManageGames
		}

		public class Role {
			public List<Permission> Permissions { get; set; }
			public string Game { get; set; }
		}

        public string Name { get; set; }
		public List<Role> Roles { get; set; }
		public string AuthHash { get; set; }
    }
}