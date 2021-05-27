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
    public record DeletePlayerCommand(int PlayerId):IRequest<AnObjectResult<Player>>;
}
