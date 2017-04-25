using System;

namespace LeaderboardService.Models
{
    [Flags]
	public enum UserPermission {
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
}