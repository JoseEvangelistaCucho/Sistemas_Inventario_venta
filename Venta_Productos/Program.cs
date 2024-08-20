namespace Venta_Productos
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
           Host.CreateDefaultBuilder(args)
               .ConfigureWebHostDefaults(webBuilder =>
               {
                   webBuilder.UseStartup<Startup>();
               })
               .ConfigureAppConfiguration((hostingContext, config) =>
               {
                   config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                   config.AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json", optional: true);
                   config.AddEnvironmentVariables();
               })
               .ConfigureServices((context, services) =>
               {
                   // No es necesario añadir nada aquí para la sesión si ya está en Startup.cs
               });
    }
}
