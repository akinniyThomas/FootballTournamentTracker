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
    public interface ITeamScoreDA
    {
        Task<AnObjectResult<TeamScore>> AddTeamScore(TeamScore teamScore, CancellationToken cancellationToken);
        Task<AnObjectResult<TeamScore>> DeleteTeamScore(int id, CancellationToken cancellationToken);
        Task<AnObjectResult<TeamScore>> UpdateTeamScore(int id, TeamScore teamScore, CancellationToken cancellationToken);

        Task<AnObjectResult<TeamScore>> GetTeamScores();
        Task<AnObjectResult<TeamScore>> GetTeamScore(int id);
    }
}
