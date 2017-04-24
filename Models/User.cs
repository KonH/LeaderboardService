using System;
using System.Collections.Generic;

namespace LeaderboardService.Models
{
    public class User
    {
		[Flags]
		public enum Permission {
			ReadScores,
			PostScores,
			UpdateScores,
			ReadUsers,
			PostUsers,
			UpdateUsers,
			ReadGames,
			PostGames,
			UpdateGames
		}

		public class Role {
			public Permission Permissions { get; set; }
			public string Game { get; set; }
		}

        public string Name { get; set; }
		public List<Role> Roles { get; set; }
		public string AuthHash { get; set; }
    }
}