using System;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using Test.Raizen.Data;
using Test.Raizen.Data.Base;
using Microsoft.AspNetCore.Builder;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Test.Raizen.Domain.AggregatesModel.ValueAggreate;

namespace Test.Raizen.Bootstrap.Providers
{
    [ExcludeFromCodeCoverage]
    public static class DatabaseBootstrap
    {
        public static IServiceCollection ConfigureDatabases(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<Func<DbConnections, IDbConnection>>(provider =>
            dbConnection => dbConnection switch
            {
                DbConnections.DEFAULT_CONNECTION => new SqlConnection(configuration.GetConnectionString("Default")),
                _ => throw new ArgumentException("Not valid DbConnections used. Will not be able to create an connection to database")
            });

            services.AddDbContextPool<TestDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Default"), b => b.MigrationsAssembly("Test.Raizen.Data")));

            return services;
        }

        public static IApplicationBuilder RunMigrations(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices
            .GetRequiredService<IServiceScopeFactory>()
            .CreateScope())
            {
                using var context = serviceScope.ServiceProvider.GetService<TestDbContext>();
                context.Database.Migrate();
            }
            return app;
        }

        public static IApplicationBuilder AddTestData(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            var context = serviceScope.ServiceProvider.GetService<TestDbContext>();
            AddTestData(context);

            return app;
        }

        public static void AddTestData(TestDbContext context)
        {
            context.Value.Add(new Value()
            {
                Id = Guid.Parse("b5d23923-27e5-42b2-a027-a96685097686"),
                Code = "Code-1",
                Description = "Description-1",
                Status = Status.Active,
                Timestamp = DateTime.Now

            });

            context.Value.Add(new Value()
            {
                Id = Guid.Parse("f580dd1f-709a-4a73-98a7-d296f3ef5c7b"),
                Code = "Code-2",
                Description = "Description-2",
                Status = Status.Active,
                Timestamp = DateTime.Now

            });

            context.Value.Add(new Value()
            {
                Id = Guid.Parse("42f30e82-4ca0-4172-abc3-5fc14e5c0559"),
                Code = "Code-3",
                Description = "Description-3",
                Status = Status.Active,
                Timestamp = DateTime.Now

            });

            context.SaveChanges();
        }
    }
}
