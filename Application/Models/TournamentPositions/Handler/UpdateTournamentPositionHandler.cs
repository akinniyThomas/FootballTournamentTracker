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
    public class UpdateTournamentPositionHandler : IRequestHandler<UpdateTournamentPositionCommand, AnObjectResult<TournamentPosition>>
    {
        private readonly ITournamentPositionDA _tournamentPosition;

        public UpdateTournamentPositionHandler(ITournamentPositionDA tournamentPosition)
        {
            _tournamentPosition = tournamentPosition;
        }

        public async Task<AnObjectResult<TournamentPosition>> Handle(UpdateTournamentPositionCommand request, CancellationToken cancellationToken) => await _tournamentPosition.UpdateTounamentPosition(request.TournamentPositionId, request.TournamentPosition, cancellationToken);
    }
}
