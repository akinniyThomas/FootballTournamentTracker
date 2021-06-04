using Application.Interfaces.DA;
using Application.Models.Tournaments.Commands;
using Application.ViewModels;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Models.Tournaments.Handler
{
    public class DeleteTournamentHandler : IRequestHandler<DeleteTournamentCommand, AnObjectResult<Tournament>>
    {
        private readonly ITournamentDA _tournament;

        public DeleteTournamentHandler(ITournamentDA tournament)
        {
            _tournament = tournament;
        }

        public async Task<AnObjectResult<Tournament>> Handle(DeleteTournamentCommand request, CancellationToken cancellationToken) => await _tournament.DeleteTournament(request.TournamentId, cancellationToken);
    }
}
