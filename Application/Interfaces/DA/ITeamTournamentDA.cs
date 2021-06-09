using Application.ViewModels;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces.DA
{
    public interface ITeamTournamentDA
    {
        Task<AnObjectResult<TeamTournament>> AddTeamTournament(int teamId, int tournamentId, CancellationToken cancellationToken);
        Task<AnObjectResult<TeamTournament>> DeleteTeamTournament(int teamId, int tournamentId, CancellationToken cancellationToken);

        Task<AnObjectResult<TeamTournament>> GetTeamTournament(int teamId, int tournamentId);
        Task<AnObjectResult<TeamTournament>> GetTeamTournaments();
    }
}
