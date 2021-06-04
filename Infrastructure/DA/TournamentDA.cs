using Application.Interfaces.DA;
using Application.ViewModels;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.DA
{
    public class TournamentDA : ITournamentDA
    {
        public Task<AnObjectResult<Tournament>> AddTournament(Tournament tournament, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<AnObjectResult<Tournament>> DeleteTournament(int tournamentId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<AnObjectResult<Tournament>> GetAllTournaments()
        {
            throw new NotImplementedException();
        }

        public Task<AnObjectResult<Tournament>> GetOneTournament(int tournamentId)
        {
            throw new NotImplementedException();
        }

        public Task<AnObjectResult<Tournament>> UpdateTournament(int tournamentId, Tournament tournament, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
