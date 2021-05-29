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
    public class GetPresentTournamentsHandler : IRequestHandler<GetPresentTournamentsQuery, AnObjectResult<TeamTournament>>
    {
        private readonly ITeamDA _team;

        public GetPresentTournamentsHandler(ITeamDA team)
        {
            _team = team;
        }

        public async Task<AnObjectResult<TeamTournament>> Handle(GetPresentTournamentsQuery request, CancellationToken cancellationToken) => await _team.GetPresentTournaments(request.TeamId);
    }
}
