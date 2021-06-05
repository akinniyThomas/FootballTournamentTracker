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
    public interface IPrizeDA
    {
        Task<AnObjectResult<Prize>> AddPrize(Prize prize, CancellationToken cancellationToken);

        Task<AnObjectResult<Prize>> DeletePrize(int id, CancellationToken cancellationToken);

        Task<AnObjectResult<Prize>> UpdatePrize(int id, Prize prize, CancellationToken cancellationToken);

        Task<AnObjectResult<Prize>> GetPrizes();
        Task<AnObjectResult<Prize>> GetPrize(int id);
    }
}
