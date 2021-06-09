using Application.Interfaces.DA;
using Application.Models.TeamTournaments.Commands;
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
    public class DeleteTeamTournamentHandler : IRequestHandler<DeleteTeamTournamentCommand, AnObjectResult<TeamTournament>>
    {
        private readonly ITeamTournamentDA _teamTournament;

        public DeleteTeamTournamentHandler(ITeamTournamentDA teamTournament)
        {
            _teamTournament = teamTournament;
        }

        public async Task<AnObjectResult<TeamTournament>> Handle(DeleteTeamTournamentCommand request, CancellationToken cancellationToken) => await _teamTournament.DeleteTeamTournament(request.TeamId, request.TournamentId, cancellationToken);
    }
}
