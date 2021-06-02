using Application.Models.Players.Queries;
using Domain.Models;
using FootballTorunament.Tests.IntegrationTests.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FootballTorunament.Tests.IntegrationTests.Teams
{
    [Collection(nameof(Testing))]
    public class AddRequest//:IClassFixture<Testing>
    {
        private readonly Testing _testFixture;

        public AddRequest(Testing testFixture)
        {
            _testFixture = testFixture;
        }

        [Fact]
        public async Task CanAddTeam()
        {
            var team = await TeamsMethods.AddNewTeam(_testFixture);

            var oddPlayer = (await PlayersMethods.AddNewPlayerToDB(_testFixture, null)).Object.FirstOrDefault();
            var players = await PlayersMethods.AddManyPlayers(_testFixture, team.Object.FirstOrDefault());

            var teamObject = team.Object.FirstOrDefault();
            var allPlayersInTeam = (await _testFixture.SendAsync(new GetAllPlayersQuery())).Object.Where(x => x.PlayerTeam.Id == teamObject.Id).Select(x => x.PlayerName);

            Assert.NotNull(team);
            Assert.NotNull(team.Object);
            Assert.NotEmpty(team.Object);
            Assert.Single(team.Object);

            Assert.True(team.Succeeded);

            Assert.Equal("", team.ErrorMessages.FirstOrDefault());

            //Assert.Equal(players[0].PlayerName, teamObject.Captain.PlayerName);
            Assert.Contains(players[0].PlayerName, allPlayersInTeam);
            Assert.Contains(players[1].PlayerName, allPlayersInTeam);
            Assert.Contains(players[2].PlayerName, allPlayersInTeam);
            Assert.Contains(players[3].PlayerName, allPlayersInTeam);

            Assert.DoesNotContain(oddPlayer.PlayerName, allPlayersInTeam);
        }

    }
}
