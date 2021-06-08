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
    public class DeleteTeamScoreHandler : IRequestHandler<DeleteTeamScoreCommand, AnObjectResult<TeamScore>>
    {
        private readonly ITeamScoreDA _teamScore;

        public DeleteTeamScoreHandler(ITeamScoreDA teamScore)
        {
            _teamScore = teamScore;
        }

        public async Task<AnObjectResult<TeamScore>> Handle(DeleteTeamScoreCommand request, CancellationToken cancellationToken) => await _teamScore.DeleteTeamScore(request.TeamScoreId, cancellationToken);
    }
}
