using Application.ViewModels;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces.DA
{
    public interface IPlayerDA
    {
        Task<AnObjectResult<Player>> AddPlayer(Player player, UserViewModel user, int? teamId, CancellationToken cancellationToken);
        Task<AnObjectResult<Player>> DeletePlayer(int playerId, CancellationToken cancellationToken);

        Task<AnObjectResult<Player>> GetPlayer(int playerId);
        Task<AnObjectResult<Player>> GetAllPlayers();
        Task<AnObjectResult<Player>> GetPlayersInTeam(int teamId);
        

        Task<AnObjectResult<Player>> UpdatePlayer(int playerId, Player player, CancellationToken cancellationToken);
    }
}
