using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using GolPooch.DependencyResolver.Ioc;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace GolPooch.Api
{
    public class Startup
    {
        private IConfiguration _config { get; }
        private readonly string AllowedOrigins = "_Origins";

        public Startup(IConfiguration configuration)
        {
            _config = configuration;
        } 

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(AllowedOrigins, builder =>
                {
                    builder
                        .WithOrigins(_config.GetSection("AllowOrigin").Value.Split(";"))
                        .SetIsOriginAllowedToAllowWildcardSubdomains()
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                });
            });
            services.AddMvc();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(opt =>
                    {
                        opt.Cookie.SameSite = SameSiteMode.Lax;
                    });
            services.AddHttpContextAccessor();


            services.AddScoped<AuthorizeFilter>();

            services.AddTransient(_config);
            services.AddScoped(_config);
            services.AddSingleton(_config);

            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.AddSwagger();

            app.UseExceptionHandler(errorApp =>
            {
                errorApp.Run(async context =>
                {
                    var errorhandler = context.Features.Get<IExceptionHandlerPathFeature>();
                    context.Response.StatusCode = 500;
                    context.Response.ContentType = "application/Json";
                    var bytes = Encoding.ASCII.GetBytes(new { IsSuccessful = false, errorhandler.Error?.Message }.ToString());
                    await context.Response.Body.WriteAsync(bytes, 0, bytes.Length);
                });
            });
            app.UseRouting();
            
            app.UseAuthentication();
            app.UseCors(AllowedOrigins);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}