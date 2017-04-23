using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using LeaderboardService.Repositories;

namespace LeaderboardService
{

	public class Program
	{
		public static void Main(string[] args)
		{
			var urls = new string[]{ "http://*:8080" };
			var host = new WebHostBuilder()
				.UseKestrel()
				.UseStartup<Startup>()
				.UseUrls(urls)
				.Build();

			host.Run();
		}
	}

	public class Startup
	{
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc();
			services.AddLogging();
			services.AddSingleton<IScoreRepository, InMemoryScoreRepository>();
			services.AddSingleton<IUserRepository, InMemoryUserRepository>();
			services.AddSingleton<IGameRepository, InMemoryGameRepository>();
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