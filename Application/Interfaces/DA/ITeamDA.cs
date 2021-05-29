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
    public interface ITeamDA
    {
        Task<AnObjectResult<Team>> GetAllTeams();
        Task<AnObjectResult<Team>> GetOneTeam(int teamId);
        Task<AnObjectResult<Player>> GetCaptain(int teamId);
        Task<AnObjectResult<TeamTournament>> GetPresentTournaments(int teamId);
        Task<AnObjectResult<TournamentPosition>> GetPastTournaments(int teamId);
        Task<AnObjectResult<Player>> GetPlayersInTeam(int teamId);

        Task<AnObjectResult<Team>> AddTeam(Team team, CancellationToken cancellation);

        Task<AnObjectResult<Team>> UpdateTeam(int teamId, Team team, CancellationToken cancellationToken);

        Task<AnObjectResult<Team>> DeleteTeam(int teamId, CancellationToken cancellation);
    }
}
