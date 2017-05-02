using Microsoft.EntityFrameworkCore;
using LeaderboardService.Models;

namespace LeaderboardService.Data
{
    public class ServiceContext : DbContext
    {
		public ServiceContext(DbContextOptions<ServiceContext> options) : base(options)
		{
		}
		
		public DbSet<Game> Games { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<Game>().ToTable("ldb_games").HasKey(g => g.Name);
		}
    }
}
