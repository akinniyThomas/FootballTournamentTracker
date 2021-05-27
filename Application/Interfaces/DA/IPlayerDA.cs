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
        Task<Player> AddPlayer(Player player, CancellationToken cancellationToken);
        Task<bool> DeletePlayer(int playerId, CancellationToken cancellationToken);
        Task<Player> GetPlayer(int playerId);
        Task<List<Player>> GetAllPlayers();
        Task<List<Player>> GetPlayersInTeam(int teamId);
        Task<Player> UpdatePlayer(int playerId, Player player, CancellationToken cancellationToken);
    }
}
