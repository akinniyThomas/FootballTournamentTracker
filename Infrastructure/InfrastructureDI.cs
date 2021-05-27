using Application.Interfaces.Context;
using Application.Interfaces.DA;
using Application.Interfaces.Identity;
using Infrastructure.Context;
using Infrastructure.DA;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class InfrastructureDI
    {
        public static  IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddIdentityServer().AddApiAuthorization<ApplicationUser, TournamentDbContext>();

            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<TournamentDbContext>();//.AddDefaultTokenProviders();

            services.AddEntityFrameworkNpgsql().AddDbContext<TournamentDbContext>(options =>
            {
                var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
                var test = Convert.ToBoolean(configuration.GetSection("test").Value);
                string connStr;
                //if()
                if (env == "Development" || test)
                {
                    connStr = configuration.GetConnectionString("ConnectionString");
                }
                else
                {
                    var connUrl = Environment.GetEnvironmentVariable("DATABASE_URL");
                    connUrl = connUrl.Replace("postgres://", string.Empty);
                    var pgUserPass = connUrl.Split("@")[0];
                    var pgHostPortDb = connUrl.Split("@")[1];
                    var pgHostPort = pgHostPortDb.Split("/")[0];
                    var pgDb = pgHostPortDb.Split("/")[1];
                    var pgUser = pgUserPass.Split(":")[0];
                    var pgPass = pgUserPass.Split(":")[1];
                    var pgHost = pgHostPort.Split(":")[0];
                    var pgPort = pgHostPort.Split(":")[1];

                    connStr = $"Server={pgHost};Port={pgPort};Username={pgUser};Password={pgPass};Database={pgDb}";
                }
                options.UseNpgsql(connStr);
            });

            services.AddScoped<IMatchDA, MatchDA>();
            services.AddScoped<IPlayerDA, PlayerDA>();
            services.AddScoped<IPrizeDA, PrizeDA>();
            services.AddScoped<ITeamDA, TeamDA>();
            services.AddScoped<ITeamScoreDA, TeamScoreDA>();
            services.AddScoped<ITeamTournamentDA, TeamTournamentDA>();
            services.AddScoped<ITournamentPositionDA, TournamentPositionDA>();
            services.AddScoped<ITournamentSelectedForDA, TournamentSelectedForDA>();
            services.AddScoped<ITournamentDA, TournamentDA>();

            services.AddScoped<ITournamentDbContext>(provider => provider.GetService<TournamentDbContext>());

            //services.AddScoped<IApplicationUserDA, ApplicationUserDA>();
            //services.AddScoped < ICurrentUserDA, CurrentUserDA >

            return services;
        }
    }
}
