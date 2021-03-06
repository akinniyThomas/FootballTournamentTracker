using Application.Interfaces.Context;
using Domain.Models;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Context
{
    public class TournamentDbContext : IdentityDbContext<IdentityUser>, ITournamentDbContext
    {
        public DbSet<Match> Matches { get; set; }
        public DbSet<Prize> Prizes { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamScore> TeamsScores { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<TournamentSelectedFor> TournamentsSelectedFor { get; set; }
        public DbSet<TeamTournament> TeamsTournaments { get; set; }
        public DbSet<TournamentPosition> TournamentPositions { get; set; }
        public DbSet<Player> Players { get; set; }

        public TournamentDbContext(DbContextOptions options) : base(options)
        {

        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            foreach (EntityEntry<AuditableEntity> entry in ChangeTracker.Entries<AuditableEntity>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.Created = DateTime.Now;
                    //entry.Entity.CreatedBy = _currentUserService.UserId;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Entity.LastModified = DateTime.Now;
                    //entry.Entity.LastModifiedBy = _currentUserService.UserId;
                }
            }
            return  base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<TeamTournament>().HasKey(c => new { c.TeamId, c.TournamentId });

            //builder.Entity<TeamTournament>()
            //    .HasOne(t => t.Team)
            //    .WithMany(t => t.PresentTournaments)
            //    .HasForeignKey(t => t.Team);

            //builder.Entity<TeamTournament>()
            //    .HasOne(t => t.Tournament)
            //    .WithMany(t => t.TeamsInTournament)
            //    .HasForeignKey(t => t.Tournament);
                
                
            //foreach (var fk in builder.Model.GetEntityTypes().SelectMany(x => x.GetForeignKeys()))
            //    fk.DeleteBehavior = DeleteBehavior.Restrict;
        }
    }
}
