using Application.Interfaces.DA;
using Application.Models.Teams.Commands;
using Application.ViewModels;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Models.Teams.Handler
{
    public class DeleteTeamHandler : IRequestHandler<DeleteTeamCommand, AnObjectResult<Team>>
    {
        private readonly ITeamDA _team;

        public DeleteTeamHandler(ITeamDA team)
        {
            _team = team;
        }

        public async Task<AnObjectResult<Team>> Handle(DeleteTeamCommand request, CancellationToken cancellationToken) => await _team.DeleteTeam(request.TeamId, cancellationToken);
    }
}
