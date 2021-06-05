using Application.Interfaces.DA;
using Application.Models.Prizes.Commands;
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
    public class UpdatePrizeHandler : IRequestHandler<UpdatePrizeCommand, AnObjectResult<Prize>>
    {
        private readonly IPrizeDA _prize;

        public UpdatePrizeHandler(IPrizeDA prize)
        {
            _prize = prize;
        }

        public async Task<AnObjectResult<Prize>> Handle(UpdatePrizeCommand request, CancellationToken cancellationToken) => await _prize.UpdatePrize(request.PrizeId, request.Prize, cancellationToken);
    }
}
