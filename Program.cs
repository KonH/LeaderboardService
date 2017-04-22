using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using LeaderboardService.Models;

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
			services.AddSingleton<IScoreRepository, ScoreRepository>();
    	}

		public void Configure(IApplicationBuilder app)
		{
			app.UseMvcWithDefaultRoute();
		}
	}
}