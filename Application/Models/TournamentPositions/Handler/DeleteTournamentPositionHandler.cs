using Application.Interfaces.DA;
using Application.Models.TournamentPositions.Commands;
using Application.ViewModels;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Models.TournamentPositions.Handler
{
    public class DeleteTournamentPositionHandler : IRequestHandler<DeleteTournamentPositionCommand, AnObjectResult<TournamentPosition>>
    {
        private readonly ITournamentPositionDA _tournamentPosition;

        public DeleteTournamentPositionHandler(ITournamentPositionDA tournamentPosition)
        {
            _tournamentPosition = tournamentPosition;
        }

        public async Task<AnObjectResult<TournamentPosition>> Handle(DeleteTournamentPositionCommand request, CancellationToken cancellationToken) => await _tournamentPosition.DeleteTournamentPosition(request.TournamentPositionId, cancellationToken);
    }
}
