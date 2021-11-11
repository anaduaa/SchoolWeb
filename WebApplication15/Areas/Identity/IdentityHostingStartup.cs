using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApplication15.Models;

[assembly: HostingStartup(typeof(WebApplication15.Areas.Identity.IdentityHostingStartup))]
namespace WebApplication15.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            

            builder.ConfigureServices((context, services) => {
                services.AddDbContext<MyDBContext>(options =>

                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("MyDBContext")));

                services.AddDefaultIdentity<MyUser>(options => options.SignIn.RequireConfirmedAccount = false).AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<MyDBContext>();
        

            });
        }
    }
}