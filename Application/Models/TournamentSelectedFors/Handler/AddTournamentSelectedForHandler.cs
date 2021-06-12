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
    public class AddTournamentSelectedForHandler : IRequestHandler<AddTournamentSelectedForCommand, AnObjectResult<TournamentSelectedFor>>
    {
        private readonly ITournamentSelectedForDA _tsf;

        public AddTournamentSelectedForHandler(ITournamentSelectedForDA tsf)
        {
            _tsf = tsf;
        }

        public async Task<AnObjectResult<TournamentSelectedFor>> Handle(AddTournamentSelectedForCommand request, CancellationToken cancellationToken) => await _tsf.AddTournamentSelectedFor(request.TournamentSelectedFor, cancellationToken);
    }
}
