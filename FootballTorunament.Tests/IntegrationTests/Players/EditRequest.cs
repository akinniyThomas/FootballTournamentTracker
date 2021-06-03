using Application.Models.Players.Commands;
using Application.Models.Players.Queries;
using Domain.Models;
using FootballTorunament.Tests.IntegrationTests.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FootballTorunament.Tests.IntegrationTests.Players
{
    [Collection(nameof(Testing))]
    public class EditRequest//:IClassFixture<Testing>
    {
        private readonly Testing _testFixture;

        public EditRequest(Testing testFixture)
        {
            _testFixture = testFixture;
        }

        [Fact]
        public async Task CanEditSuccessfully()
        {
            var objectResult = await PlayersMethods.AddNewPlayerToDB(_testFixture,null);
            var player = objectResult.Object.FirstOrDefault();

            player.Age = 999;

            var result = await _testFixture.SendAsync(new UpdatePlayerCommand(player.Id, player));

            Assert.True(result.Succeeded);
            Assert.Equal("", result.ErrorMessages.FirstOrDefault());
            Assert.NotNull(result.Object);
            Assert.NotEmpty(result.Object);
            Assert.Equal(999, result.Object.FirstOrDefault().Age);

            var findPlayer = await _testFixture.SendAsync(new GetPlayerByIdQuery(result.Object.FirstOrDefault().Id));
            var findPlayerObject = findPlayer.Object;

            Assert.True(findPlayer.Succeeded);
            Assert.NotNull(findPlayerObject);
            Assert.NotEmpty(findPlayerObject);
            Assert.Single(findPlayerObject);
            Assert.Equal(999, findPlayerObject.FirstOrDefault().Age);
        }

        [Fact]
        public async Task CanUpdateTeam()
        {
            var team = (await TeamsMethods.AddNewTeamToDB(_testFixture)).Object.FirstOrDefault();
            var newTeam = (await TeamsMethods.AddNewTeamToDB(_testFixture)).Object.FirstOrDefault();

            var objectResult = await PlayersMethods.AddNewPlayerToDB(_testFixture, team);
            var player = objectResult.Object.FirstOrDefault();

            player.Age = 999;
            player.PlayerTeam.Id = newTeam.Id;

            var result = await _testFixture.SendAsync(new UpdatePlayerCommand(player.Id, player));

            Assert.True(result.Succeeded);
            Assert.Equal("", result.ErrorMessages.FirstOrDefault());
            Assert.NotNull(result.Object);
            Assert.NotEmpty(result.Object);
            Assert.Equal(999, result.Object.FirstOrDefault().Age);
            Assert.Equal(player.PlayerTeam.Id, result.Object.FirstOrDefault().PlayerTeam.Id);
            Assert.NotEqual(player.PlayerTeam.Id, team.Id);

            var findPlayer = await _testFixture.SendAsync(new GetPlayerByIdQuery(result.Object.FirstOrDefault().Id));
            var findPlayerObject = findPlayer.Object;

            Assert.True(findPlayer.Succeeded);
            Assert.NotNull(findPlayerObject);
            Assert.NotEmpty(findPlayerObject);
            Assert.Single(findPlayerObject);
            Assert.Equal(999, findPlayerObject.FirstOrDefault().Age);
            Assert.Equal(player.PlayerTeam.Id, findPlayerObject.FirstOrDefault().PlayerTeam.Id);
        }

        [Fact]
        public async Task PlayerIsNull()
        {
            var objectResult = await PlayersMethods.AddNewPlayerToDB(_testFixture, null);
            var player = objectResult.Object.FirstOrDefault();

            player.Age = 999;

            var result = await _testFixture.SendAsync(new UpdatePlayerCommand(player.Id, null));
            var error = "Player to be updated is empty!";

            Assert.False(result.Succeeded);
            Assert.Contains(error, result.ErrorMessages);
            Assert.Null(result.Object);
        }

        [Fact]
        public async Task PlayerIdIsWrong()
        {
            var objectResult = await PlayersMethods.AddNewPlayerToDB(_testFixture, null);
            var player = objectResult.Object.FirstOrDefault();

            player.Age = 999;

            var result = await _testFixture.SendAsync(new UpdatePlayerCommand(-1, player));
            var error = "Player to be updated is not correct!";

            Assert.False(result.Succeeded);
            Assert.Contains(error, result.ErrorMessages);
            Assert.Null(result.Object);
        }

        [Fact]
        public async Task MoreThanOneCaptain()
        {
            //var team = await TeamsMethods.AddNewTeamToDB(_testFixture);
            //var player = PlayersMethods.AddPlayerDetails(15, new DateTime(1992, 1, 1), "this is the player name", Domain.Enums.Sex.Both, _testFixture.CreateUserModel($"user{PlayersMethods.AddPlayerCount}@user.com", $"user{PlayersMethods.AddPlayerCount}@user.com", "password123P{", "password123P{", $"phoneNumber{PlayersMethods.AddPlayerCount}"), team.Object.FirstOrDefault());
            //PlayersMethods.AddPlayerCount++;
            //await _testFixture.SendAsync(player);



            var error = "Can not have more than one captain at a time, Remove the last captain before making another player the captain!";
            var team = (await TeamsMethods.AddNewTeamToDB(_testFixture)).Object.FirstOrDefault();
            var players = await PlayersMethods.AddManyPlayers(_testFixture, team);

            players[0].IsCaptain = true;
            players[1].IsCaptain = true;

            await _testFixture.SendAsync(new UpdatePlayerCommand(players[0].Id, players[0]));
            var result = await _testFixture.SendAsync(new UpdatePlayerCommand(players[1].Id, players[1]));

            Assert.False(result.Succeeded);
            Assert.Contains(error, result.ErrorMessages);
            Assert.Null(result.Object);
        }

        [Fact]
        public async Task PlayerIdIsForDifferentPlayer()
        {
            var objectResult = await PlayersMethods.AddNewPlayerToDB(_testFixture, null);

            var player = objectResult.Object.FirstOrDefault();
            var playerId = (await PlayersMethods.AddNewPlayerToDB(_testFixture, null)).Object.FirstOrDefault().Id;

            player.Age = 999;

            var result = await _testFixture.SendAsync(new UpdatePlayerCommand(playerId, player));
            var error = "Trying to update the wrong player, please check again and try afterwards!";

            Assert.False(result.Succeeded);
            Assert.Contains(error, result.ErrorMessages);
            Assert.Null(result.Object);
        }
    }
}
