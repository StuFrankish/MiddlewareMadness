﻿using ApiMiddleware.Extensions;

namespace WebApplication1;

public class Startup(IConfiguration configuration, IWebHostEnvironment hostEnvironment)
{
    private readonly IConfiguration _configuration = configuration;
    private readonly IWebHostEnvironment _environment = hostEnvironment;

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllersWithViews();

        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        services.AddMyMiddleware(opt => {

            opt.Endpoints.EnableInfoEndpoint = true;
            opt.Endpoints.EnableUIEndpoint = true;
            opt.Endpoints.EnableResourceEndpoint = true;

        });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
    {
        app.UseStaticFiles();
        app.UseRouting();

        app.UseEndpoints(endpoints => {
            endpoints.MapControllerRoute(name: "areas", pattern: "{area}/{controller}/{action=Index}/{id?}");
            endpoints.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
            endpoints.MapControllerRoute(name: "file", pattern: "{controller=Home}/{action=Index}/{id?}/{fileName}");
        });

        app.UseMyMiddleware();
    }
}
