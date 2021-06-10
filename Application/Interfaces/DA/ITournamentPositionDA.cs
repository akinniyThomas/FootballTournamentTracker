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
    public interface ITournamentPositionDA
    {
        Task<AnObjectResult<TournamentPosition>> AddTournamentPosition(TournamentPosition tournamentPosition, CancellationToken cancellationToken);

        Task<AnObjectResult<TournamentPosition>> DeleteTournamentPosition(int tournamentPositionId, CancellationToken cancellationToken);

        Task<AnObjectResult<TournamentPosition>> UpdateTounamentPosition(int tournamentPositionId, TournamentPosition tournamentPosition, CancellationToken cancellationToken);

        Task<AnObjectResult<TournamentPosition>> GetTournamentPositions();

        Task<AnObjectResult<TournamentPosition>> GetTournamentPosition(int tournamentPositionId);
    }
}
