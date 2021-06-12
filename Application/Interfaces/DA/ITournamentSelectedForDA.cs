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
    public interface ITournamentSelectedForDA
    {
        Task<AnObjectResult<TournamentSelectedFor>> AddTournamentSelectedFor(TournamentSelectedFor tsf,CancellationToken cancellationToken);
        Task<AnObjectResult<TournamentSelectedFor>> DeleteTournamentSelectedFor(int tsfId, CancellationToken cancellationToken);
        Task<AnObjectResult<TournamentSelectedFor>> UpdateTournamentSelectedFor(int tsfId, TournamentSelectedFor tsf, CancellationToken cancellationToken);

        Task<AnObjectResult<TournamentSelectedFor>> GetTournamentSelectedFors();
        Task<AnObjectResult<TournamentSelectedFor>> GetTournamentSelectedFor(int tsfId);
    }
}
