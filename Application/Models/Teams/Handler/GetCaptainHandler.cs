using Application.Interfaces.DA;
using Application.Models.Teams.Queries;
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
    public class GetCaptainHandler : IRequestHandler<GetCaptainQuery, AnObjectResult<Player>>
    {
        private readonly ITeamDA _team;

        public GetCaptainHandler(ITeamDA team)
        {
            _team = team;
        }

        public async Task<AnObjectResult<Player>> Handle(GetCaptainQuery request, CancellationToken cancellationToken) => await _team.GetCaptain(request.TeamId);
    }
}
