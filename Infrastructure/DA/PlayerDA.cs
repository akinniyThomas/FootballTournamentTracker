using Application.Extensions;
using Application.Interfaces.Context;
using Application.Interfaces.DA;
using Application.ViewModels;
using Domain.Models;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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

        public async Task<AnObjectResult<Player>> AddPlayer(Player player, UserViewModel user, int? teamId, CancellationToken cancellationToken)
        {
            if (user.IsNotNull() && player.IsNotNull())
            {
                var identityUser = ReturnIdentityUser(user);
                if (user.ConfirmPassword == user.Password)
                {
                    var result = await _userManager.CreateAsync(identityUser, user.Password);
                    if (result.Succeeded)
                    {
                        if (teamId.IsNotNull())
                        {
                            var team = await _tournamentContext.Teams.FindAsync(teamId);
                            player.PlayerTeam = team;
                        }
                        player.ApplicationUserId = identityUser.Id;
                        await _tournamentContext.Players.AddAsync(player);
                        await _tournamentContext.SaveChangesAsync(cancellationToken);
                        return AnObjectResult<Player>.ReturnObjectResult(player, true, "");
                    }
                    return AnObjectResult<Player>.ReturnObjectResult(false, ConcatinateStrings(result.Errors.Select(x => x.Description).ToList(), "Could not add User"));
                }
                return AnObjectResult<Player>.ReturnObjectResult(false, ConcatinateStrings("Password and Confirm Password are not same!"));
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

        public Task<AnObjectResult<Player>> GetAllPlayers() => Task.FromResult(AnObjectResult<Player>.ReturnObjectResult(_tournamentContext.Players?.ToList(), true, ""));

        public Task<AnObjectResult<Player>> GetPlayer(int playerId)
        {
            var player = _tournamentContext.Players.Include(p => p.PlayerTeam).FirstOrDefault(x => x.Id == playerId);
            if (player.IsNotNull())
                return Task.FromResult(AnObjectResult<Player>.ReturnObjectResult(player, true, ""));
            return Task.FromResult(AnObjectResult<Player>.ReturnObjectResult(false, $"No Player with given {playerId} Exists"));
        }

        public Task<AnObjectResult<Player>> GetPlayersInTeam(int teamId)
        {
            var players = _tournamentContext.Players.Where(x => x.PlayerTeam.Id == teamId).ToList();
            return Task.FromResult(AnObjectResult<Player>.ReturnObjectResult(players, true, ""));
        }

        public async Task<AnObjectResult<Player>> UpdatePlayer(int playerId, Player player, CancellationToken cancellationToken)
        {
            if (player.IsNotNull())
            {
                var returnPlayer = await _tournamentContext.Players.FindAsync(playerId);
                if (returnPlayer.IsNotNull())
                {
                    if(player.IsCaptain)
                    {
                        var captains = _tournamentContext.Players.Where(x => x.PlayerTeam.Id == player.PlayerTeam.Id).Where(x => x.IsCaptain);
                        if (captains.Count() == 1 && captains.FirstOrDefault().Id != player.Id)
                            return AnObjectResult<Player>.ReturnObjectResult(false, "Can not have more than one captain at a time, Remove the last captain before making another player the captain!");
                    }
                    if (returnPlayer.Id == player.Id)
                    {
                        returnPlayer.Age = player.Age;
                        returnPlayer.DOB = player.DOB;
                        returnPlayer.IsRetired = player.IsRetired;
                        returnPlayer.PlayerName = player.PlayerName;
                        returnPlayer.PlayerSex = player.PlayerSex;
                        returnPlayer.IsCaptain = player.IsCaptain;
                        returnPlayer.PlayerTeam = await _tournamentContext.Teams.FindAsync(player.PlayerTeam?.Id);

                        await _tournamentContext.SaveChangesAsync(cancellationToken);
                        return AnObjectResult<Player>.ReturnObjectResult(returnPlayer, true, "");
                    }
                    return AnObjectResult<Player>.ReturnObjectResult(false, "Trying to update the wrong player, please check again and try afterwards!");
                }
                return AnObjectResult<Player>.ReturnObjectResult(false, "Player to be updated is not correct!");
            }
            return AnObjectResult<Player>.ReturnObjectResult(false, "Player to be updated is empty!");
        }

        public static List<string> ConcatinateStrings(List<string> list, params string[] strings) => list.Concat(strings.ToList()).ToList();

        public static List<string> ConcatinateStrings(params string[] strings) => strings.ToList();

        public static IdentityUser ReturnIdentityUser(UserViewModel user) => new()
        {
            UserName = user.UserName,
            Email = user.EmailAddress,
            PhoneNumber = user.PhoneNumber
        };
    }
}
