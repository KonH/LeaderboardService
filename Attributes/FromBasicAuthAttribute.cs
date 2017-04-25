using Microsoft.AspNetCore.Mvc;

namespace LeaderboardService
{
    public class FromBasicAuthAttribute:FromHeaderAttribute
    {
        public FromBasicAuthAttribute() {
			Name = "Authorization";
		}
    }
}