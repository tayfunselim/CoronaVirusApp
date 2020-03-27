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
                services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<CoronaVirusDbContext>(); 
            });
        }
    }
}