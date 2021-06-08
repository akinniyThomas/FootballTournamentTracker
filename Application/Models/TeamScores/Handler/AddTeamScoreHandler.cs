using Application.Interfaces.DA;
using Application.Models.TeamScores.Commands;
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
    public class AddTeamScoreHandler : IRequestHandler<AddTeamScoreCommand, AnObjectResult<TeamScore>>
    {
        private readonly ITeamScoreDA _teamScore;

        public AddTeamScoreHandler(ITeamScoreDA teamScore)
        {
            _teamScore = teamScore;
        }
        public async Task<AnObjectResult<TeamScore>> Handle(AddTeamScoreCommand request, CancellationToken cancellationToken) => await _teamScore.AddTeamScore(request.TeamScore, cancellationToken);
    }
}
