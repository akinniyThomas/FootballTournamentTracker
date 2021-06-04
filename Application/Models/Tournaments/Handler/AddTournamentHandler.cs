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
    public class AddTournamentHandler : IRequestHandler<AddTournamentCommand, AnObjectResult<Tournament>>
    {
        private readonly ITournamentDA _tournament;

        public AddTournamentHandler(ITournamentDA tournament)
        {
            _tournament = tournament;
        }

        public async Task<AnObjectResult<Tournament>> Handle(AddTournamentCommand request, CancellationToken cancellationToken) => await _tournament.AddTournament(request.Tournament, cancellationToken);
    }
}
