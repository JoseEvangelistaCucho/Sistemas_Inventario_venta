using Microsoft.AspNetCore.Server.Kestrel.Core;
using Venta_Productos.Infrastructure;

namespace Venta_Productos
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            string cadenaConexion = Configuration.GetConnectionString("DefaultConnection");

            services.AddControllersWithViews();
            services.AddHttpContextAccessor();

            services.Configure<KestrelServerOptions>(options =>
            {
                options.Limits.MaxRequestBodySize = 20971520;
            });

            // Añadir servicios de sesión
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            services.AddInfrastructure(Configuration);

            services.AddControllersWithViews();
            services.AddHttpContextAccessor();
            services.AddRazorPages();

            services.AddLogging(logging =>
            {
                logging.AddEventLog();
            });

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseCors();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            // app.UseSession(); // Añadir el middleware de sesión aquí

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}");
            });
        }
    }
}
