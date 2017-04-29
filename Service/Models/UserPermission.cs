using System;

namespace LeaderboardService.Models
{
    [Flags]
	public enum UserPermission {
		ReadScores = 1,
		PostScores = 2,
		UpdateScores = 4,
		ReadUsers = 8,
		PostUsers = 16,
		UpdateUsers = 32,
		ReadGames = 64,
		PostGames = 128,
		UpdateGames = 256
	}
}