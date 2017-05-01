using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace LeaderboardService
{

	public class Program
	{
		public static void Main(string[] args)
		{
			var urls = new string[]{ "http://*:8080" };
			var host = new WebHostBuilder()
				.UseEnvironment("Development")
				.UseKestrel()
				.UseStartup<Startup>()
				.UseUrls(urls)
				.Build();

			host.Run();
		}
	}
}