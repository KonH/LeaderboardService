using LeaderboardService.Models;

namespace LeaderboardService.Managers
{
    public interface IAuthManager
    {
		int StatusCode { get; }
        bool IsAllowed(string header, UserPermission permission);
		bool IsAllowed(string header, string game, UserPermission permission);
    }
}