using LeaderboardService.Managers;
using LeaderboardService.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace LeaderboardService
{
    public class Startup
	{
		IHostingEnvironment Env { get; set; }

		public Startup(IHostingEnvironment env)
		{
			Env = env;
		}

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc();
			services.AddLogging();
			services.AddSingleton<IScoreRepository, InMemoryScoreRepository>();
			services.AddSingleton<IUserRepository, InMemoryUserRepository>();
			services.AddSingleton<IGameRepository, InMemoryGameRepository>();
			if ( Env.IsDevelopment() )
			{
				services.AddTransient<IAuthManager, NoAuthManager>();
			}
			else 
			{
				services.AddTransient<IAuthManager, AuthManager>();
			}
			services.AddSwaggerGen();
    	}

		public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
		{
			app.UseMvcWithDefaultRoute();
			app.UseSwagger();
			app.UseSwaggerUi();
			loggerFactory.AddConsole().AddDebug();
		}
	}
}