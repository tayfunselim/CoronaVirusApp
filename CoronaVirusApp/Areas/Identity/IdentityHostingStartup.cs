using CoronaVirusApp.Core.Managment;
using CoronaVirusApp.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(CoronaVirusApp.Areas.Identity.IdentityHostingStartup))]
namespace CoronaVirusApp.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddIdentity<ApplicationUser, ApplicationUserRole>(options =>
                {
                    options.Password.RequiredLength = 8;
                    options.Password.RequireDigit = true;
                    options.Password.RequireLowercase = true;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = true;
                })
                .AddDefaultUI()
                .AddEntityFrameworkStores<CoronaVirusDbContext>();
            });
        }
    }
}