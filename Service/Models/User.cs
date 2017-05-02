using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LeaderboardService.Models
{
    public class User
    {
		[Key]
        public string Name { get; set; }
		public string Password { get; set; }
		public List<UserRole> Roles { get; set; }
    }
}