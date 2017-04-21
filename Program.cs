using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

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
            services.AddRouting();
        }

        public void Configure(IApplicationBuilder app)
        {  
            var defaultRouteHandler = new RouteHandler(context =>
            {
                return context.Response.WriteAsync("LeaderboardService v.1.0.0");
            });
            var routeBuilder = new RouteBuilder(app, defaultRouteHandler);
            routeBuilder.MapRoute("default", "");
            var routes = routeBuilder.Build();
            app.UseRouter(routes);
        }
    }
}