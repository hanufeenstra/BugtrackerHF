using System.Runtime.InteropServices.ComTypes;
using Microsoft.EntityFrameworkCore;
using Auth0.AspNetCore.Authentication;
using BugtrackerHF.DAL;
using BugtrackerHF.DAL.Data;
using BugtrackerHF.DAL.Repositories;
using BugtrackerHF.Models;
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
            });

            services.AddDbContext<BugtrackerHFContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("BugtrackerHFContext") ?? throw new InvalidOperationException("Connection string 'BugtrackerHFContext' not found.")));

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IIssueRepository, IssueRepository>();
            services.AddTransient<IMessageRepository, MessageRepository>();

            services.AddDistributedMemoryCache();
            services.AddMvcCore();
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
            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(routes =>
            {
                routes.MapControllerRoute(
                    name: "Default",
                    pattern: "{controller=Login}/{action=Login}");

                routes.MapControllerRoute(
                    name: "CreateIssue",
                    pattern: "{controller=CreateIssue}/{action=CreateIssue}");

                routes.MapControllerRoute(
                    name: "Register",
                    pattern: "{controller=Register}/{action=Register}");

                routes.MapControllerRoute(
                    name: "Dashboard",
                    pattern: "{controller=Index}/{action=Dashboard}");

                routes.MapControllerRoute(
                    name: "ForgotPassword",
                    pattern: "{controller=ForgotPassword}/{action=ForgotPassword}");

                routes.MapControllerRoute(
                    name: "Index",
                    pattern: "{controller=Index}/{action=Index}");

                routes.MapControllerRoute(
                    name: "Login",
                    pattern: "{controller=Login}/{action=Login}");

            });
        }
    }
}
