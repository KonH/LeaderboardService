using Microsoft.AspNetCore.Hosting;

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
}