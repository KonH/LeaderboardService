using System;
using LeaderboardService.Managers;
using LeaderboardService.Repositories;
using LeaderboardService.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

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
			services.AddLogging();
			services.AddDbContext<ServiceContext>(options => options.UseInMemoryDatabase(Guid.NewGuid().ToString()));
			services.AddMvc();
			services.AddSingleton<IScoreRepository, InMemoryScoreRepository>();
			services.AddSingleton<IUserRepository, InMemoryUserRepository>();
			services.AddSingleton<IGameRepository, DbGameRepository>();
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

		public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, ServiceContext dbContext)
		{
			app.UseMvcWithDefaultRoute();
			app.UseSwagger();
			app.UseSwaggerUi();
			loggerFactory.AddConsole().AddDebug();
		}
	}
}