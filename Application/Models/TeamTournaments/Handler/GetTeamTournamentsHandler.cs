using Application.Interfaces.DA;
using Application.Models.TeamTournaments.Queries;
using Application.ViewModels;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Models.TeamTournaments.Handler
{
    public class GetTeamTournamentsHandler : IRequestHandler<GetTeamTournamentsQuery, AnObjectResult<TeamTournament>>
    {
        private readonly ITeamTournamentDA _teamTournament;

        public GetTeamTournamentsHandler(ITeamTournamentDA teamTournament)
        {
            _teamTournament = teamTournament;
        }

        public async Task<AnObjectResult<TeamTournament>> Handle(GetTeamTournamentsQuery request, CancellationToken cancellationToken) => await _teamTournament.GetTeamTournaments();
    }
}
