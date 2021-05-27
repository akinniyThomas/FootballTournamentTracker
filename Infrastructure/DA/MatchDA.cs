using Application.Interfaces.Context;
using Application.Interfaces.DA;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.DA
{
    public class MatchDA : IMatchDA
    {
        private readonly ITournamentDbContext _tournamentContext;

        public MatchDA(ITournamentDbContext tournamentContext)
        {
            _tournamentContext = tournamentContext;
        }

        public Task<Match> AddMatch(Match match, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteMatch(int matchId)
        {
            throw new NotImplementedException();
        }

        public Task<Match> GetMatch(int matchId)
        {
            throw new NotImplementedException();
        }

        public Task<Match> GetMatchByVsTeamsInTournament(int teamId1, int teamId2, int tournamentId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Match>> GetMatches()
        {
            throw new NotImplementedException();
        }

        public Task<List<Match>> GetMatchesByTeam(int teamId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Match>> GetMatchesByVsTeams(int teamId1, int teamId2)
        {
            throw new NotImplementedException();
        }

        public Task<List<Match>> GetMatchesInTournament(int tournamentId)
        {
            throw new NotImplementedException();
        }

        public Task<Match> UpdateMatch(int matchId, Match match, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
