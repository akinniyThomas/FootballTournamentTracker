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

        public Task<AnObjectResult<Player>> GetAllPlayers() => Task.FromResult(AnObjectResult<Player>.ReturnObjectResult(_tournamentContext.Players?.ToList(), true, ""));

        public async Task<AnObjectResult<Player>> GetPlayer(int playerId)
        {
            var player = await _tournamentContext.Players.FindAsync(playerId);
            if (player != null)
                return AnObjectResult<Player>.ReturnObjectResult(player, true, "");
            return AnObjectResult<Player>.ReturnObjectResult(false, $"No Player with given {playerId} Exists");
        }

        public Task<AnObjectResult<Player>> GetPlayersInTeam(int teamId)
        {
            throw new NotImplementedException();
        }

        public async Task<AnObjectResult<Player>> UpdatePlayer(int playerId, Player player, CancellationToken cancellationToken)
        {
            if (player.IsNotNull())
            {
                var returnPlayer = await _tournamentContext.Players.FindAsync(playerId);
                if (returnPlayer.IsNotNull())
                {
                    //var updatedPlayer = FilledPlayerData(player, returnPlayer);
                    if (returnPlayer.Id == player.Id)
                    {
                        returnPlayer.Age = player.Age;
                        returnPlayer.DOB = player.DOB;
                        returnPlayer.IsRetired = player.IsRetired;
                        returnPlayer.PlayerName = player.PlayerName;
                        returnPlayer.PlayerSex = player.PlayerSex;

                        await _tournamentContext.SaveChangesAsync(cancellationToken);
                        return AnObjectResult<Player>.ReturnObjectResult(returnPlayer, true, "");
                    }
                    return AnObjectResult<Player>.ReturnObjectResult(false, "Trying to update the wrong player, please check again and try afterwards!");
                }
                return AnObjectResult<Player>.ReturnObjectResult(false, "Player to be updated is not correct!");
            }
            return AnObjectResult<Player>.ReturnObjectResult(false, "Player to be updated is empty!");
        }

        public async Task<AnObjectResult<Player>> UpdatePlayerTournamentSelected(int playerId, TournamentSelectedFor tournamentSelected, CancellationToken cancellationToken)
        {
            await _tournamentContext.SaveChangesAsync(cancellationToken);
            return AnObjectResult<Player>.ReturnObjectResult(true, "");
        }

        public List<string> ConcatinateStrings(List<string> list, params string[] strings) => list.Concat(strings.ToList()).ToList();

        public List<string> ConcatinateStrings(params string[] strings) => strings.ToList();

        public IdentityUser ReturnIdentityUser(UserViewModel user) => new()
        {
            UserName = user.UserName,
            Email = user.EmailAddress,
            PhoneNumber = user.PhoneNumber
        };

        public Player FilledPlayerData(Player incomingPlayer, Player updatedPlayer)
        {
            updatedPlayer.Age = incomingPlayer.Age;
            updatedPlayer.DOB = incomingPlayer.DOB;
            updatedPlayer.IsRetired = incomingPlayer.IsRetired;
            updatedPlayer.IsSelected = incomingPlayer.IsSelected;
            updatedPlayer.PlayerName = incomingPlayer.PlayerName;
            updatedPlayer.PlayerSex = incomingPlayer.PlayerSex;
            return updatedPlayer;
        }

        public async Task<AnObjectResult<TournamentSelectedFor>> GetAllTournamentSelectedFor(int playerId)
        {
            var player = await GetPlayer(playerId);
            if (player.Succeeded) {
                var tournaments = player.Object.FirstOrDefault().IsSelected?.ToList();
                if (tournaments.IsNotNull())
                    return AnObjectResult<TournamentSelectedFor>.ReturnObjectResult(tournaments, true, "");
                return AnObjectResult<TournamentSelectedFor>.ReturnObjectResult(false, "Player has no tournament!");
            }
            return AnObjectResult<TournamentSelectedFor>.ReturnObjectResult(false, player.ErrorMessages);
        }

        public async Task<AnObjectResult<TournamentSelectedFor>> GetOneTournamentSelectedFor(int playerId, int tournamentId)
        {
            var tournaments = await GetAllTournamentSelectedFor(playerId);
            if (tournaments.Object.IsNotNull())
            {
                var tournament = tournaments.Object.FirstOrDefault(x => x.Tournament.Id == tournamentId);
                if (tournament.IsNotNull())
                    return AnObjectResult<TournamentSelectedFor>.ReturnObjectResult(tournament, true, "");
                return AnObjectResult<TournamentSelectedFor>.ReturnObjectResult(false, "");
            }
            return AnObjectResult<TournamentSelectedFor>.ReturnObjectResult(false, tournaments.ErrorMessages);
        }
    }
}
