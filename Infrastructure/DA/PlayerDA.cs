using Application.Extensions;
using Application.Interfaces.Context;
using Application.Interfaces.DA;
using Application.ViewModels;
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
        private readonly UserManager<IdentityUser> _userManager;

        public PlayerDA(ITournamentDbContext tournamentContext, UserManager<IdentityUser> userManager)
        {
            _tournamentContext = tournamentContext;
            _userManager = userManager;
        }

        public async Task<AnObjectResult<Player>> AddPlayer(Player player, UserViewModel user, CancellationToken cancellationToken)
        {
            if (user.IsNotNull() && player.IsNotNull())
            {
                var identityUser = ReturnIdentityUser(user);
                var result = await _userManager.CreateAsync(identityUser, user.Password);
                if (result.Succeeded)
                {
                    player.ApplicationUserId = identityUser.Id;
                    await _tournamentContext.Players.AddAsync(player);
                    await _tournamentContext.SaveChangesAsync(cancellationToken);
                    return AnObjectResult<Player>.ReturnObjectResult(player, true, "");
                }
                return AnObjectResult<Player>.ReturnObjectResult(false, ConcatinateStrings(result.Errors.Select(x => x.Description).ToList(), "Could not add User"));
            }
            if (!player.IsNotNull())
                return AnObjectResult<Player>.ReturnObjectResult(false, "No player detail is given");
            return AnObjectResult<Player>.ReturnObjectResult(false, "No user detail is given");
        }

        public async Task<AnObjectResult<Player>> DeletePlayer(int playerId, CancellationToken cancellationToken)
        {
            var player = await _tournamentContext.Players.FindAsync(playerId);
            if (player.IsNotNull())
            {
                var user = await _userManager.FindByIdAsync(player.ApplicationUserId);
                if (user.IsNotNull())
                {
                    var result = await _userManager.DeleteAsync(user);
                    if (result.Succeeded)
                    {
                        _tournamentContext.Players.Remove(player);
                        await _tournamentContext.SaveChangesAsync(cancellationToken);
                        return AnObjectResult<Player>.ReturnObjectResult(true, "");
                    }
                    else return AnObjectResult<Player>.ReturnObjectResult(false, ConcatinateStrings(result.Errors.Select(x => x.Description).ToList(), $"Unable to delete User - {user.UserName}"));
                }
                else return AnObjectResult<Player>.ReturnObjectResult(false, "User you are trying to delete doesn't exist");
            }
            else return AnObjectResult<Player>.ReturnObjectResult(false, "Player you are trying to delete doesn't exist!");
        }

        public Task<AnObjectResult<Player>> GetAllPlayers()
        {
            throw new NotImplementedException();
        }

        public Task<AnObjectResult<Player>> GetPlayer(int playerId)
        {
            throw new NotImplementedException();
        }

        public Task<AnObjectResult<Player>> GetPlayersInTeam(int teamId)
        {
            throw new NotImplementedException();
        }

        public IdentityUser ReturnIdentityUser(UserViewModel user) => new()
        {
            UserName = user.UserName,
            Email = user.EmailAddress,
            PhoneNumber = user.PhoneNumber
        };

        public Task<AnObjectResult<Player>> UpdatePlayer(int playerId, Player player, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public List<string> ConcatinateStrings(List<string> list, params string[] strings) => list.Concat(strings.ToList()).ToList();

        public List<string> ConcatinateStrings(params string[] strings) => strings.ToList();
    }
}
