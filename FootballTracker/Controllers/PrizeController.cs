using Application.Models.Prizes.Commands;
using Application.Models.Prizes.Queries;
using Application.ViewModels;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballTracker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PrizeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PrizeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<AnObjectResult<Prize>> GetPrizes() => await _mediator.Send(new GetPrizesQuery());

        [HttpGet("{id}")]
        public async Task<AnObjectResult<Prize>> GetPrize(int id) => await _mediator.Send(new GetOnePrizeQuery(id));

        [HttpPost]
        public async Task<AnObjectResult<Prize>> AddPrize(Prize prize) => await _mediator.Send(new AddPrizeCommand(prize));

        [HttpPut("{id}")]
        public async Task<AnObjectResult<Prize>> UpdatePrize(int id, Prize prize) => await _mediator.Send(new UpdatePrizeCommand(id, prize));

        [HttpDelete("{id}")]
        public async Task<AnObjectResult<Prize>> DeletePrize(int id) => await _mediator.Send(new DeletePrizeCommand(id));
    }
}
