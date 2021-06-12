using Application.Interfaces.DA;
using Application.Models.TournamentSelectedFors.Commands;
using Application.ViewModels;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Models.TournamentSelectedFors.Handler
{
    public class DeleteTournamentSelectedForHandler : IRequestHandler<DeleteTournamentSelectedForCommand, AnObjectResult<TournamentSelectedFor>>
    {
        private readonly ITournamentSelectedForDA _tsf;

        public DeleteTournamentSelectedForHandler(ITournamentSelectedForDA tsf)
        {
            _tsf = tsf;
        }

        public async Task<AnObjectResult<TournamentSelectedFor>> Handle(DeleteTournamentSelectedForCommand request, CancellationToken cancellationToken) => await _tsf.DeleteTournamentSelectedFor(request.TsfId, cancellationToken);
    }
}
