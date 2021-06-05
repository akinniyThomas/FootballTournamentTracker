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
    public class GetOnePrizeHandler : IRequestHandler<GetOnePrizeQuery, AnObjectResult<Prize>>
    {
        private readonly IPrizeDA _prize;

        public GetOnePrizeHandler(IPrizeDA prize)
        {
            _prize = prize;
        }

        public async Task<AnObjectResult<Prize>> Handle(GetOnePrizeQuery request, CancellationToken cancellationToken) => await _prize.GetPrize(request.PrizeId);
    }
}
