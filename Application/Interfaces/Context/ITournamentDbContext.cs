using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces.Context
{
    public interface ITournamentDbContext
    {
        DbSet<Match> Matches { get; set; }
        DbSet<Prize> Prizes { get; set; }
        DbSet<Team> Teams { get; set; }
        DbSet<TeamScore> TeamsScores { get; set; }
        DbSet<Tournament> Tournaments { get; set; }
        DbSet<TournamentSelectedFor> TournamentsSelectedFor { get; set; }
        public DbSet<TeamTournament> TeamsTournaments { get; set; }
        public DbSet<TournamentPosition> TournamentPositions { get; set; }
        public DbSet<Player> Players { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
