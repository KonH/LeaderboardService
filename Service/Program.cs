using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace LeaderboardService
{

	public class Program
	{
		public static IConfigurationRoot Configuration { get; set; }

		public static Dictionary<string, string> GetSwitchMappings(IReadOnlyDictionary<string, string> configurationStrings)
		{
			return configurationStrings.Select(item =>
				new KeyValuePair<string, string>(
					"-" + item.Key.Substring(item.Key.LastIndexOf(':') + 1),
					item.Key))
					.ToDictionary(
						item => item.Key, item => item.Value);
		}

		public static void Main(string[] args)
		{
			var configParams = new Dictionary<string, string> 
			{
				{ "Port", "8080" },
				{ "Env", "Production" },
				{ "MySQL", "server=localhost;userid=root;password=root;database=leaderboards;"}
			};
			var configBuilder = new ConfigurationBuilder();
			configBuilder.AddInMemoryCollection(configParams).AddCommandLine(args, GetSwitchMappings(configParams));
			Configuration = configBuilder.Build();

			var port = Configuration.GetValue<string>("Port");
			var env = Configuration.GetValue<string>("Env");
			var mysql = Configuration.GetValue<string>("MySQL");

			Console.WriteLine();
			Console.WriteLine("Configuration:");
			Console.WriteLine("Port: '{0}'", port);
			Console.WriteLine("Env: '{0}'", env);
			Console.WriteLine("MySQL: '{0}'", mysql);
			Console.WriteLine();

			var urls = new string[]{ "http://*:" + port };
			var host = new WebHostBuilder()
				.UseEnvironment(env)
				.UseKestrel()
				.UseStartup<Startup>()
				.UseUrls(urls)
				.Build();

			host.Run();
		}
	}
}