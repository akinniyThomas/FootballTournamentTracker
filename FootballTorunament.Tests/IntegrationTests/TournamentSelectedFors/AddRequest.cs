using Application.Models.TournamentSelectedFors.Commands;
using Domain.Models;
using FootballTorunament.Tests.IntegrationTests.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FootballTorunament.Tests.IntegrationTests.TournamentSelected
{
    [Collection(nameof(Testing))]
    public class AddRequest
    {
        private readonly Testing _testFixture;

        public AddRequest(Testing testFixture)
        {
            _testFixture = testFixture;
        }

        [Fact]
        public async Task CanAddTournamentSelectedFor()
        {
            var team = (await TeamsMethods.AddNewTeamToDB(_testFixture)).Object.FirstOrDefault();
            var player = (await PlayersMethods.AddNewPlayerToDB(_testFixture, team)).Object.FirstOrDefault();
            var tournament = (await TournamentsMethods.AddTournament(_testFixture)).Object.FirstOrDefault();

            TournamentSelectedFor tsf = new()
            {
                Player = player,
                Tournament = tournament,
                IsSelected = false
            };

            var result = await _testFixture.SendAsync(new AddTournamentSelectedForCommand(tsf));

            Assert.True(result.Succeeded);
            Assert.NotNull(result.Object);
            Assert.NotEmpty(result.Object);
            Assert.Single(result.Object);
            Assert.Equal("", result.ErrorMessages.FirstOrDefault());
        }

        [Fact]
        public async Task TournamentSelectedForIsNull()
        {
            var result = await _testFixture.SendAsync(new AddTournamentSelectedForCommand(null));

            var error = "TournamentSelectedFor Cannot be empty!";

            Assert.False(result.Succeeded);
            Assert.Null(result.Object);
            Assert.Equal(error, result.ErrorMessages.FirstOrDefault());
        }

        [Fact]
        public async Task TournamentIsNull()
        {
            var team = (await TeamsMethods.AddNewTeamToDB(_testFixture)).Object.FirstOrDefault();
            var player = (await PlayersMethods.AddNewPlayerToDB(_testFixture, team)).Object.FirstOrDefault();

            TournamentSelectedFor tsf = new()
            {
                Player = player,
                Tournament = null,
                IsSelected = false
            };

            var result = await _testFixture.SendAsync(new AddTournamentSelectedForCommand(tsf));

            var error = "Either Player or Tournament For the TournamentSelectedFor is Empty!";

            Assert.False(result.Succeeded);
            Assert.Null(result.Object);
            Assert.Equal(error, result.ErrorMessages.FirstOrDefault());
        }

        [Fact]
        public async Task PlayerIsNull()
        {
            var tournament = (await TournamentsMethods.AddTournament(_testFixture)).Object.FirstOrDefault();

            TournamentSelectedFor tsf = new()
            {
                Player = null,
                Tournament = tournament,
                IsSelected = false
            };

            var result = await _testFixture.SendAsync(new AddTournamentSelectedForCommand(tsf));

            var error = "Either Player or Tournament For the TournamentSelectedFor is Empty!";

            Assert.False(result.Succeeded);
            Assert.Null(result.Object);
            Assert.Equal(error, result.ErrorMessages.FirstOrDefault());
        }
    }
}
