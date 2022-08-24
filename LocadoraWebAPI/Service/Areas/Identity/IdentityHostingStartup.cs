using System;
using LocadoraWebAPI.Areas.Identity.Data;
using LocadoraWebAPI.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(LocadoraWebAPI.Areas.Identity.IdentityHostingStartup))]
namespace LocadoraWebAPI.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<LocadoraWebAPIContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("LocadoraWebAPIContextConnection")));

                services.AddDefaultIdentity<LocadoraWebAPIUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<LocadoraWebAPIContext>();
            });
        }
    }
}