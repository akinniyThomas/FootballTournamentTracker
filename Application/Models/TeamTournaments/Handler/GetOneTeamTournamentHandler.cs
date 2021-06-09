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
    public class GetOneTeamTournamentHandler : IRequestHandler<GetOneTeamTournamentQuery, AnObjectResult<TeamTournament>>
    {
        private readonly ITeamTournamentDA _teamTournament;

        public GetOneTeamTournamentHandler(ITeamTournamentDA teamTournament)
        {
            _teamTournament = teamTournament;
        }

        public async Task<AnObjectResult<TeamTournament>> Handle(GetOneTeamTournamentQuery request, CancellationToken cancellationToken) => await _teamTournament.GetTeamTournament(request.TeamId, request.TournamentId);
    }
}
