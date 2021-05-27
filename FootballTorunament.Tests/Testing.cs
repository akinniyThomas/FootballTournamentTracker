using FootballTracker;
using Infrastructure.Context;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using Respawn;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FootballTorunament.Tests
{
    [CollectionDefinition(nameof(Testing))]
    public class TestFixtureCollection : ICollectionFixture<Testing> { }

    public class Testing : IAsyncLifetime
    {
        private static IConfigurationRoot _configuration;
        private static IServiceScopeFactory _scopeFactory;
        private static Checkpoint _checkpoint;

        public Testing()
        {
            ConfigurationBuild();

            var services = StartUpServicesConfiguration();
            //services.AddScoped<IMatchDA, MatchDA>();
            //services.AddScoped<ITournamentDbContext, TournamentDbContext>();
            MigrateDB(services);

            SetCheckPoint();
        }

        public void ConfigurationBuild()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", true, true).AddEnvironmentVariables();

            _configuration = builder.Build();
        }

        public ServiceCollection StartUpServicesConfiguration()
        {
            var startup = new Startup(_configuration);
            var services = new ServiceCollection();
            services.AddLogging();
            startup.ConfigureServices(services);
            return services;
        }

        public void MigrateDB(ServiceCollection services)
        {
            _scopeFactory = services.BuildServiceProvider().GetService<IServiceScopeFactory>();
            var scopedProvider = _scopeFactory.CreateScope().ServiceProvider;
            var scopedProviderContext = scopedProvider.GetService<TournamentDbContext>();
            scopedProviderContext.Database.Migrate();

        }

        public void SetCheckPoint()
        {
            _checkpoint = new Checkpoint
            {
                TablesToIgnore = new[]
                   {
                    "__EFMigrationsHistory"
                },
                DbAdapter = DbAdapter.Postgres
            };
        }

        public async Task ResetDB()
        {
            var connectionString = _configuration.GetConnectionString("ConnectionString");
            using (var connection = new NpgsqlConnection(connectionString))
            {
                await connection.OpenAsync();
                await _checkpoint.Reset(connection);
            }
        }

        public Task DisposeAsync()
        {
            return Task.CompletedTask;
        }

        public async Task InitializeAsync()
        {
            await ResetDB();
        }

        public async Task ExecuteScopeAsync(Func<IServiceProvider, Task> action)
        {
            using var scope = _scopeFactory.CreateScope();
            var dbContext = scope.ServiceProvider.GetService<TournamentDbContext>();

            try
            {
                //await dbContext.BeginTransactionAsync();
                await action(scope.ServiceProvider);
                //await dbContext.CommitTransactionAsync();
            }
            catch (Exception)
            {
                //dbContext.RollbackTransactoin();
                throw;
            }
        }

        public async Task<T> ExecuteScopeAsync<T>(Func<IServiceProvider, Task<T>> action)
        {
            using var scope = _scopeFactory.CreateScope();
            var dbContext = scope.ServiceProvider.GetService<TournamentDbContext>();

            try
            {
                //await dbContext.BeginTransactionAsync();
                var result = await action(scope.ServiceProvider);
                //await dbContext.CommitTransactionAsync();
                return result;
            }
            catch (Exception)
            {
                //dbContext.RollbackTransactoin();
                throw;
            }
        }

        public Task ExecuteContextAsync(Func<TournamentDbContext, Task> action) => ExecuteScopeAsync(sp => action(sp.GetService<TournamentDbContext>()));

        public async Task<T> FindAsync<T>(int id) where T:class
        {
            return await _scopeFactory.CreateScope().ServiceProvider.GetService<TournamentDbContext>().FindAsync<T>(id);
        }

        public async Task AddAsync<T>(T t) where T : class
        {
            var context = _scopeFactory.CreateScope().ServiceProvider.GetService<TournamentDbContext>();
            await context.AddAsync(t);
            await context.SaveChangesAsync();
        }

        public async Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request)
        {
            using var scope = _scopeFactory.CreateScope();

            var mediator = scope.ServiceProvider.GetService<ISender>();

            return await mediator.Send(request);
        }


        public async Task<string> RunAsUserAsync(string userName, string password, string phoneNumber, string[] roles)
        {
            using var scope = _scopeFactory.CreateScope();

            var userManager = scope.ServiceProvider.GetService<UserManager<IdentityUser>>();

            var user = new IdentityUser { UserName = userName, Email = userName };

            var result = await userManager.CreateAsync(user, password);

            if (roles.Any())
            {
                var roleManager = scope.ServiceProvider.GetService<RoleManager<IdentityRole>>();

                foreach (var role in roles)
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }

                await userManager.AddToRolesAsync(user, roles);
            }

            if (result.Succeeded)
            {


                return user.Id;
            }
            else return null;
        }


    }
}
