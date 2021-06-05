using Application.Interfaces.DA;
using Application.Models.Prizes.Queries;
using Application.ViewModels;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Models.Prizes.Handler
{
    public class GetPrizesHandler : IRequestHandler<GetPrizesQuery, AnObjectResult<Prize>>
    {
        private readonly IPrizeDA _prize;

        public GetPrizesHandler(IPrizeDA prize)
        {
            _prize = prize;
        }

        public async Task<AnObjectResult<Prize>> Handle(GetPrizesQuery request, CancellationToken cancellationToken) => await _prize.GetPrizes();
    }
}
