using System.Runtime.InteropServices.ComTypes;
using Microsoft.EntityFrameworkCore;
using Auth0.AspNetCore.Authentication;
using BugtrackerHF.DAL;
using BugtrackerHF.DAL.Data;
using BugtrackerHF.DAL.GenericRepository;
using BugtrackerHF.DAL.Repositories;
using BugtrackerHF.DAL.UnitOfWork;
using BugtrackerHF.Services;
using BugtrackerHF.Support;
using Microsoft.AspNetCore.Authentication;

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
                options.UseSqlServer(Configuration.GetConnectionString("BugtrackerHFContextDev") ?? throw new InvalidOperationException("Connection string 'BugtrackerHFContext' not found.")));

            services.AddDistributedMemoryCache();
            services.AddMvcCore();
            services.AddRazorPages();

            services.AddScoped<IClaimsTransformation, ClaimsTransformation>();

            #region DAL
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IIssueRepository, IssueRepository>();
            services.AddScoped<IMessageRepository, MessageRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            #endregion

            #region Services
            services.AddScoped<IIssueService, IssueService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IDashboardService, DashboardService>();
            #endregion

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
                    name: "Dashboard",
                    pattern: "{controller=Index}/{action=Dashboard}");

                routes.MapControllerRoute(
                    name: "Index",
                    pattern: "{controller=Index}/{action=Index}");

                routes.MapControllerRoute(
                    name: "Issue",
                    pattern: "{controller=Issue}/{action=Create}");

                routes.MapControllerRoute(
                    name: "Login",
                    pattern: "{controller=Login}/{action=Login}");

                routes.MapControllerRoute(
                    name: "Logout",
                    pattern: "{controller=Logout}/{action=Logout}");

                routes.MapControllerRoute(
                    name: "Profile",
                    pattern: "{controller=Profile}/{action=View}");
            });
        }
    }
}
