using Application.ViewModels;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.TournamentSelectedFors.Commands
{
    public record DeleteTournamentSelectedForCommand(int TsfId) : IRequest<AnObjectResult<TournamentSelectedFor>>;
}
