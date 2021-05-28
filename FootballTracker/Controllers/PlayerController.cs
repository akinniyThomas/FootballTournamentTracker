﻿using Application.Models.Players.Commands;
using Application.ViewModels;
using Domain.Models;
using FootballTracker.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballTracker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayerController:ControllerBase
    {
        private readonly IMediator _mediator;

        public PlayerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<AnObjectResult<Player>> AddPlayer(UserPlayerViewModel request)
        {
            return await _mediator.Send(new AddPlayerCommand(request.Player, request.User));
        }

        [HttpDelete("id")]
        public async Task<AnObjectResult<Player>> DeletePlayer(int id)
        {
            return await _mediator.Send(new DeletePlayerCommand(id));
        }
    }
}
