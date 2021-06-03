using Application.ViewModels;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Players.Commands
{
    public record AddPlayerCommand(Player Player, UserViewModel User, int? TeamId) : IRequest<AnObjectResult<Player>>;
}
