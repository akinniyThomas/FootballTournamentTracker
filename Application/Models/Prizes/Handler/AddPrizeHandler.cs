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
    public class AddPrizeHandler : IRequestHandler<AddPrizeCommand, AnObjectResult<Prize>>
    {
        private readonly IPrizeDA _prize;

        public AddPrizeHandler(IPrizeDA prize)
        {
            _prize = prize;
        }
        public async Task<AnObjectResult<Prize>> Handle(AddPrizeCommand request, CancellationToken cancellationToken) => await _prize.AddPrize(request.Prize, cancellationToken);
    }
}
