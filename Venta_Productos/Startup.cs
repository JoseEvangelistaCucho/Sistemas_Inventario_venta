using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Venta_Productos.Infrastructure.Data;
using Venta_Productos.Models;
using Venta_Productos.Service.ProductosServicios;

public class Startup
{
	public Startup(IConfiguration configuration)
	{
		Configuration = configuration;
	}

	public IConfiguration Configuration { get; }

	public void ConfigureServices(IServiceCollection services)
	{
        services.AddSingleton<ConexionBD>();
        services.AddSingleton<ProductoSC>();
        
        // Otros servicios
        services.AddControllersWithViews();
		services.AddHttpContextAccessor();

		// Configuración de MediatR
		services.AddMediatR(Assembly.GetExecutingAssembly());

		// Configuración de sesión, logging, CORS, etc.
		services.AddDistributedMemoryCache();
		services.AddSession(options =>
		{
			options.IdleTimeout = TimeSpan.FromMinutes(30);
			options.Cookie.HttpOnly = true;
			options.Cookie.IsEssential = true;
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

		services.AddLogging(logging =>
		{
			logging.AddEventLog();
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

		// Añadir el middleware de sesión
		app.UseSession();

		app.UseAuthorization();

		app.UseEndpoints(endpoints =>
		{
			endpoints.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");
		});
	}
}
