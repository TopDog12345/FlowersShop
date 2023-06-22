using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Slobodianuik.University.Example.Database.Interfaces;
using Slobodianuik.University.Example.Database.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Slobodianuik.University.Example.Database
{
    public static class DIConfiguration
    {
        public static void RegisterDatabaseDependencies(this IServiceCollection services, IConfigurationRoot configuration)
        {
            services.AddDbContext<FlowersShopDbContext>((x) => x.UseSqlServer(configuration.GetConnectionString("FlowersShopDatabase")));
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddScoped(typeof(IDbEntityService<>), typeof(DbEntityService<>));
        }

        public static void RegisterIdentityDependencies(this IServiceCollection services)
        {
            services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<FlowersShopDbContext>();
        }
    }
}
