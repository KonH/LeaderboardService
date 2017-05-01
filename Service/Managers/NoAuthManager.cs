using LeaderboardService.Models;
using Microsoft.AspNetCore.Mvc;

namespace LeaderboardService.Managers
{
    public class NoAuthManager : IAuthManager
    {
        public IActionResult Result { get { return null; } }
		public int StatusCode { get { return 200; } }
        
		public bool IsAllowed(string header, UserPermission permission)
		{
			return true;
		}
		public bool IsAllowed(string header, string game, UserPermission permission)
		{
			return true;
		}
    }
}