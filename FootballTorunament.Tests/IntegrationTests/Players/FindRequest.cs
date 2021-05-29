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
    public class FindRequest//:IClassFixture<Testing>
    {
        private readonly Testing _testFixture;

        public FindRequest(Testing testFixture)
        {
            _testFixture = testFixture;
        }

        [Fact]
        public async Task CanGetOnePlayer()
        {
            var player = (await PlayersMethods.AddNewPlayerToDB(_testFixture)).Object.FirstOrDefault();

            var result = (await _testFixture.SendAsync(new GetPlayerByIdQuery(player.Id)));
            var playerDetails = result.Object.FirstOrDefault();


            Assert.NotNull(result);
            Assert.True(result.Succeeded);
            Assert.NotNull(result.Object);
            Assert.NotEmpty(result.Object);
            Assert.Equal(player.DOB, playerDetails.DOB);
            Assert.Equal(player.PlayerName, playerDetails.PlayerName);
            Assert.Equal(player.Id, playerDetails.Id);
            Assert.Single(result.Object);
        }

        [Fact]
        public async Task PlayerIdIsWrong()
        {
            var result = await _testFixture.SendAsync(new GetPlayerByIdQuery(1));

            var error = "No Player with given";

            Assert.NotNull(result);
            Assert.False(result.Succeeded);
            Assert.Null(result.Object);
            Assert.Matches(error, result.ErrorMessages.FirstOrDefault());
        }

        [Fact]
        public async Task CanGetManyPlayers()
        {
            var players = await PlayersMethods.AddManyPlayers(_testFixture);
            var result = await _testFixture.SendAsync(new GetAllPlayersQuery());
            //Player
            Assert.NotNull(result);
            Assert.True(result.Succeeded);
            Assert.NotNull(result.Object);
            Assert.NotEmpty(result.Object);
            Assert.Contains(players[0].Id, result.Object.Select(x=>x.Id));
            Assert.Contains(players[1].Id, result.Object.Select(x => x.Id));
            Assert.Contains(players[2].Id, result.Object.Select(x => x.Id));
            Assert.Contains(players[3].Id, result.Object.Select(x => x.Id));

            var player = await PlayersMethods.AddNewPlayerToDB(_testFixture);

            Assert.True(player.Succeeded);
            Assert.DoesNotContain(player.Object.FirstOrDefault().Id, result.Object.Select(x => x.Id));
        }

        [Fact(Skip = "Not Implemented Yet!")]
        public async Task GetAllTournamentsPlayerIsSelectedFor()
        {
            var players = await PlayersMethods.AddManyPlayers(_testFixture);

            //then add some tournaments

            //then add a new tournamentSelectedFor

            //then get all tournamentsSelectedFor for a Player

            //assert it
        }

        [Fact(Skip ="Not Implemented Yet!")]
        public async Task GetOneTournamentPlayerIsSelectedFor()
        {
            var players = await PlayersMethods.AddManyPlayers(_testFixture);

            //then add some tournaments

            //then add a new tournamentSelectedFor

            //then get all tournamentsSelectedFor for a Player in a particular tournament

            //assert it
        }

        [Fact(Skip="Until Teams Come In Play")]
        public async Task GetPlayersInATeam()
        {
            var players = await PlayersMethods.AddManyPlayers(_testFixture);

            Domain.Models.Team team = new()
            {
                Players = new List<Player>() {
                    players[0],
                    players[1]
                },
                Captain = players[0],
                TeamName="TeamName"
            };


            var result = await _testFixture.SendAsync(new GetAllPlayersQuery());
            //Player
            Assert.NotNull(result);
            Assert.True(result.Succeeded);
            Assert.NotNull(result.Object);
            Assert.NotEmpty(result.Object);
            Assert.Contains(players[0].Id, result.Object.Select(x => x.Id));
            Assert.Contains(players[1].Id, result.Object.Select(x => x.Id));
            Assert.Contains(players[2].Id, result.Object.Select(x => x.Id));
            Assert.Contains(players[3].Id, result.Object.Select(x => x.Id));
        }
    }
}
