using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Players.Queries
{
    public record GetPlayersInTeamQuery(int TeamId) : IRequest<List<Player>>;
}
