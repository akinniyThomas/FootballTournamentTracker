                        using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces.DA
{
    public interface IMatchDA
    {
        Task<Match> AddMatch(Match match, CancellationToken cancellationToken);
        Task<bool> DeleteMatch(int matchId);
        Task<Match> GetMatch(int matchId);
        Task<Match> GetMatchByVsTeamsInTournament(int teamId1, int teamId2, int tournamentId);
        Task<List<Match>> GetMatches();
        Task<List<Match>> GetMatchesByTeam(int teamId);
        Task<List<Match>> GetMatchesByVsTeams(int teamId1, int teamId2);
        Task<List<Match>> GetMatchesInTournament(int tournamentId);
        Task<Match> UpdateMatch(int matchId, Match match, CancellationToken cancellationToken);
    }
}
