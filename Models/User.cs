using System;
using System.Collections.Generic;

namespace LeaderboardService.Models
{
    public class User
    {
        public string Name { get; set; }
		public string Password { get; set; }
		public List<UserRole> Roles { get; set; }
    }
}