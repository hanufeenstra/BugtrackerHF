using Auth0.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;

namespace BugtrackerHF.src
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

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IIssueRepository, IssueRepository>();
            services.AddTransient<IMessageRepository, MessageRepository>();

            services.AddScoped<IClaimsTransformation, ClaimsTransformation>();
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
