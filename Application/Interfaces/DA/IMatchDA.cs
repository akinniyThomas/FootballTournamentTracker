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
    public interface IMatchDA
    {
        Task<AnObjectResult<Match>> AddMatch(Match match, CancellationToken cancellationToken);
        Task<AnObjectResult<Match>> DeleteMatch(int matchId, CancellationToken cancellationToken);

        Task<AnObjectResult<Match>> GetMatch(int matchId);
        Task<AnObjectResult<Match>> GetMatches();

        Task<AnObjectResult<Match>> UpdateMatch(int matchId, Match match, CancellationToken cancellationToken);
    }
}
