using Application.Interfaces.DA;
using Application.Models.TeamScores.Queries;
using Application.ViewModels;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Models.TeamScores.Handler
{
    public class GetTeamScoreHandler : IRequestHandler<GetTeamScoresQuery, AnObjectResult<TeamScore>>
    {
        private readonly ITeamScoreDA _teamScore;

        public GetTeamScoreHandler(ITeamScoreDA teamScore)
        {
            _teamScore = teamScore;
        }

        public async Task<AnObjectResult<TeamScore>> Handle(GetTeamScoresQuery request, CancellationToken cancellationToken) => await _teamScore.GetTeamScores();
    }
}
