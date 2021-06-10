using Application.Models.TournamentPositions.Commands;
using Domain.Models;
using FootballTorunament.Tests.IntegrationTests.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FootballTorunament.Tests.IntegrationTests.TournamentPositions
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
        public async Task CanAddTournamentPosition()
        {
            var tournament = (await TournamentsMethods.AddTournament(_testFixture)).Object.FirstOrDefault();
            var team = (await TeamsMethods.AddNewTeamToDB(_testFixture)).Object.FirstOrDefault();
            TournamentPosition tp = new()
            {
                Tournament = tournament,
                Team = team,
                Position = 2
            };

            var result = await _testFixture.SendAsync(new AddTournamentPositionCommand(tp));

            Assert.True(result.Succeeded);
            Assert.NotNull(result.Object);
            Assert.NotEmpty(result.Object);
            Assert.Single(result.Object);
            Assert.Equal("", result.ErrorMessages.FirstOrDefault());
        }

        [Fact]
        public async Task TournamentPositionIsNull()
        {
            var tournament = (await TournamentsMethods.AddTournament(_testFixture)).Object.FirstOrDefault();
            var team = (await TeamsMethods.AddNewTeamToDB(_testFixture)).Object.FirstOrDefault();
            TournamentPosition tp = new()
            {
                Tournament = tournament,
                Team = team,
                Position = 2
            };

            var result = await _testFixture.SendAsync(new AddTournamentPositionCommand(null));

            var error = "Tournament Position Cannot be empty!";
            Assert.False(result.Succeeded);
            Assert.Null(result.Object);
            Assert.Equal(error, result.ErrorMessages.FirstOrDefault());
        }

        [Fact]
        public async Task TeamIsNull()
        {
            var tournament = (await TournamentsMethods.AddTournament(_testFixture)).Object.FirstOrDefault();
            var team = (await TeamsMethods.AddNewTeamToDB(_testFixture)).Object.FirstOrDefault();
            TournamentPosition tp = new()
            {
                Tournament = tournament,
                Team = null,
                Position = 2
            };

            var result = await _testFixture.SendAsync(new AddTournamentPositionCommand(tp));

            var error = "Team or Tournament for the position cannot be empty!";
            Assert.False(result.Succeeded);
            Assert.Null(result.Object);
            Assert.Equal(error, result.ErrorMessages.FirstOrDefault());
        }

        [Fact]
        public async Task TournamentIsNull()
        {
            var tournament = (await TournamentsMethods.AddTournament(_testFixture)).Object.FirstOrDefault();
            var team = (await TeamsMethods.AddNewTeamToDB(_testFixture)).Object.FirstOrDefault();
            TournamentPosition tp = new()
            {
                Tournament = null,
                Team = team,
                Position = 2
            };

            var result = await _testFixture.SendAsync(new AddTournamentPositionCommand(tp));

            var error = "Team or Tournament for the position cannot be empty!";
            Assert.False(result.Succeeded);
            Assert.Null(result.Object);
            Assert.Equal(error, result.ErrorMessages.FirstOrDefault());
        }
    }
}
