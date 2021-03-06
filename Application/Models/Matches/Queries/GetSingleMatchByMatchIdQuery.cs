using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Matches.Queries
{
    public record GetSingleMatchByMatchIdQuery(int MatchId):IRequest<Match>;
}
