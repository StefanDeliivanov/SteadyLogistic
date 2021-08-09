namespace SteadyLogistic.Infrastructure.Extensions
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Newtonsoft.Json;
    using SteadyLogistic.Data;
    using SteadyLogistic.Data.Models;
    using SteadyLogistic.Models.Seed;

    using static SteadyLogistic.Areas.AreaGlobalConstants.Admin;
    using static SteadyLogistic.Areas.AreaGlobalConstants.Roles;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder PrepareDatabase(
            this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            var services = serviceScope.ServiceProvider;

            MigrateDatabase(services);

            SeedCargoSizes(services);
            SeedTrailerTypes(services);
            SeedCountries(services);
            SeedAdministrator(services, AdministratorRoleName);
            SeedRole(services, MemberRoleName);
            SeedRole(services, ManagerRoleName);
            SeedRole(services, PremiumRoleName);

            return app;
        }

        private static void MigrateDatabase(IServiceProvider services)
        {
            var data = services.GetRequiredService<SteadyLogisticDbContext>();

            data.Database.Migrate();
        }

        private static void SeedAdministrator(IServiceProvider services, string roleName)
        {
            var userManager = services.GetRequiredService<UserManager<User>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            Task
                .Run(async () =>
                {
                    if (await roleManager.RoleExistsAsync(roleName))
                    {
                        return;
                    }

                    SeedRole(services, AdministratorRoleName);

                    var user = new User
                    {
                        Email = defaultAdminEmail,
                        UserName = defaultAdminEmail,
                    };

                    await userManager.CreateAsync(user, defaultAdminPassword);

                    await userManager.AddToRoleAsync(user, AdministratorRoleName);
                })
                .GetAwaiter()
                .GetResult();
        }

        private static void SeedRole(IServiceProvider services, string roleName)
        {
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            Task
                .Run(async () =>
                {
                    if (await roleManager.RoleExistsAsync(roleName))
                    {
                        return;
                    }

                    var role = new IdentityRole { Name = roleName };

                    await roleManager.CreateAsync(role);
                })
                .GetAwaiter()
                .GetResult();
        }

        private static void SeedCargoSizes(IServiceProvider services)
        {
            var data = services.GetRequiredService<SteadyLogisticDbContext>();

            if (data.CargoSizes.Any())
            {
                return;
            }

            data.CargoSizes.AddRange(new[]
            {
                new CargoSize { Name = "Full Load" },
                new CargoSize { Name = "Groupage" }
            });

            data.SaveChanges();
        }

        private static void SeedCountries(IServiceProvider services)
        {
            var data = services.GetRequiredService<SteadyLogisticDbContext>();

            if (data.Countries.Any())
            {
                return;
            }

            var europeCountriesToAdd = new List<CountrySeedModel>();

            using (StreamReader reader = new("Data/Seeds/europeCountriesSLogistics.json"))
            {
                string allCountries = reader.ReadToEnd();
                europeCountriesToAdd = JsonConvert.DeserializeObject<List<CountrySeedModel>>(allCountries);
            }

            foreach (var item in europeCountriesToAdd)
            {
                data.Countries.Add(new Country { Name = item.Name, Code = item.Code });
            }

            data.SaveChanges();
        }

        private static void SeedTrailerTypes(IServiceProvider services)
        {
            var data = services.GetRequiredService<SteadyLogisticDbContext>();

            if (data.TrailerTypes.Any())
            {
                return;
            }

            data.TrailerTypes.AddRange(new[]
            {
                new TrailerType { Name = "Box" },
                new TrailerType { Name = "Flatbed" },
                new TrailerType { Name = "Jumbo" },
                new TrailerType { Name = "Mega" },
                new TrailerType { Name = "Refrigerator" },
                new TrailerType { Name = "Tank" },
                new TrailerType { Name = "Tautliner" },
            });

            data.SaveChanges();
        }
    }
}