using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaderboardService.Models
{
    public class User
    {
		[Key]
        public string Name { get; set; }
		public string Password { get; set; }
		[NotMapped]
		public List<UserRole> Roles { get; set; }
    }
}