using Application.ViewModels;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces.DA
{
    public interface ITournamentDA
    {
        Task<AnObjectResult<Tournament>> GetAllTournaments();
        Task<AnObjectResult<Tournament>> GetOneTournament(int tournamentId);

        Task<AnObjectResult<Tournament>> AddTournament(Tournament tournament, CancellationToken cancellationToken);
        Task<AnObjectResult<Tournament>> UpdateTournament(int tournamentId, Tournament tournament, CancellationToken cancellationToken);
        Task<AnObjectResult<Tournament>> DeleteTournament(int tournamentId, CancellationToken cancellationToken);
    }
}
