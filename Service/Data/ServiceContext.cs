using Microsoft.EntityFrameworkCore;
using LeaderboardService.Models;

namespace LeaderboardService.Data
{
    public class ServiceContext : DbContext
    {
		public ServiceContext(DbContextOptions<ServiceContext> options) : base(options)
		{
			Database.EnsureCreated();
		}
		
		public DbSet<Game> Games { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<UserRole> Roles { get; set; }
		public DbSet<ScoreItem> Scores { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<Game>().HasKey(g => g.Name);
			builder.Entity<User>().HasKey(u => u.Name);
			builder.Entity<UserRole>().HasKey("User", "Game");
			builder.Entity<ScoreItem>().HasKey(s => s.Key);
		}
    }
}
