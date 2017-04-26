using LeaderboardService.Managers;
using LeaderboardService.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace LeaderboardService
{
    public class Startup
	{
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddAuthorization();
			services.AddMvc();
			services.AddLogging();
			services.AddSingleton<IScoreRepository, InMemoryScoreRepository>();
			services.AddSingleton<IUserRepository, InMemoryUserRepository>();
			services.AddSingleton<IGameRepository, InMemoryGameRepository>();
			services.AddTransient<IAuthManager, AuthManager>();
			services.AddSwaggerGen();
    	}

		public void Configure(IApplicationBuilder app)
		{
			app.UseMvcWithDefaultRoute();
			app.UseSwagger();
			app.UseSwaggerUi();
		}
	}
}