using Application.Interfaces.Context;
using Application.Interfaces.DA;
using Domain.Models;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.DA
{
    public class PlayerDA : IPlayerDA
    {
        private readonly ITournamentDbContext _tournamentContext;
        

        public PlayerDA(ITournamentDbContext tournamentContext)
        {
            _tournamentContext = tournamentContext;
        }

        public async Task<Player> AddPlayer(Player player, CancellationToken cancellationToken)
        {
            if (player != null)
            {
                await _tournamentContext.Players.AddAsync(player);
                await _tournamentContext.SaveChangesAsync(cancellationToken);
            }
            return player;
        }

        public Task<bool> DeletePlayer(int playerId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<List<Player>> GetAllPlayers()
        {
            throw new NotImplementedException();
        }

        public Task<Player> GetPlayer(int playerId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Player>> GetPlayersInTeam(int teamId)
        {
            throw new NotImplementedException();
        }

        public Task<Player> UpdatePlayer(int playerId, Player player, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
