using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace FinTransact.Gateway
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Configuration.SetBasePath(builder.Environment.ContentRootPath)
               .AddJsonFile("ocelot.json", optional: false, reloadOnChange: true)
               .AddEnvironmentVariables();

            builder.Services.AddOcelot(builder.Configuration);

            var app = builder.Build();

            app.UseOcelot();

            //app.MapGet("/", () => "Hello World!");


            app.Run();
        }
    }
}
