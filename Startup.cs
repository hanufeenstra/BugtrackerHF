using Microsoft.EntityFrameworkCore;
using Auth0.AspNetCore.Authentication;
using BugtrackerHF.DAL;
using BugtrackerHF.DAL.Data;
using BugtrackerHF.Support;

namespace BugtrackerHF
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
            services.ConfigureSameSiteNoneCookies();

            services.AddAuth0WebAppAuthentication(options =>
            {
                options.Domain = Configuration["Auth0:Domain"];
                options.ClientId = Configuration["Auth0:ClientId"];
                //options.ClientSecret = Configuration["Auth0:ClientSecret"];
            });
                //.WithAccessToken(options =>
                //{
                    //options.Audience = Configuration["Auth0:Audience"];
                    //options.UseRefreshTokens = true;
                //});


            services.AddDbContext<BugtrackerHFContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("BugtrackerHFContext") ?? throw new InvalidOperationException("Connection string 'BugtrackerHFContext' not found.")));

            services.AddDistributedMemoryCache();
            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "Default",
                    pattern: "{controller=Login}/{action=Login}");

                endpoints.MapControllerRoute(
                    name: "CreateIssue",
                    pattern: "{controller=CreateIssue}/{action=CreateIssue}");

                endpoints.MapControllerRoute(
                    name: "Register",
                    pattern: "{controller=Register}/{action=Register}");

                endpoints.MapControllerRoute(
                    name: "Dashboard",
                    pattern: "{controller=Index}/{action=Dashboard}");

                endpoints.MapControllerRoute(
                    name: "ForgotPassword",
                    pattern: "{controller=ForgotPassword}/{action=ForgotPassword}");

                endpoints.MapControllerRoute(
                    name: "Index",
                    pattern: "{controller=Index}/{action=Index}");

                endpoints.MapControllerRoute(
                    name: "Login",
                    pattern: "{controller=Login}/{action=Login}");

            });
        }
    }
}
