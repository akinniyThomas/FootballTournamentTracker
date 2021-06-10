using Application.Models.TournamentPositions.Commands;
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
    public class EditRequest
    {
        private readonly Testing _testFixture;

        public EditRequest(Testing testFixture)
        {
            _testFixture = testFixture;
        }

        [Fact]
        public async Task CanUpdateTournamentPosition()
        {
            var tp = (await TournamentPostionsMethods.AddNewTournamentPosition(_testFixture)).Object.FirstOrDefault();
            tp.Position = 3;
            var team = (await TeamsMethods.AddNewTeamToDB(_testFixture)).Object.FirstOrDefault();
            tp.Team = team;
            var result = await _testFixture.SendAsync(new UpdateTournamentPositionCommand(tp.Id, tp));

            Assert.True(result.Succeeded);
            Assert.NotNull(result.Object);
            Assert.NotEmpty(result.Object);
            Assert.Single(result.Object);
            Assert.Equal("", result.ErrorMessages.FirstOrDefault());

            var resultObject = result.Object.FirstOrDefault();
            Assert.Equal(tp.Position, resultObject.Position);
            Assert.Equal(tp.Team.Id, resultObject.Team.Id);
        }

        [Fact]
        public async Task TournamentPositionIsNull()
        {
            var tp = (await TournamentPostionsMethods.AddNewTournamentPosition(_testFixture)).Object.FirstOrDefault();
            tp.Position = 3;
            var team = (await TeamsMethods.AddNewTeamToDB(_testFixture)).Object.FirstOrDefault();
            tp.Team = team;
            var result = await _testFixture.SendAsync(new UpdateTournamentPositionCommand(tp.Id, null));

            var error = "No such Tournament Position Exists!";
            Assert.False(result.Succeeded);
            Assert.Null(result.Object);
            Assert.Equal(error, result.ErrorMessages.FirstOrDefault());
        }

        [Fact]
        public async Task TournamentPositionIdDoesNotExist()
        {
            var tp = (await TournamentPostionsMethods.AddNewTournamentPosition(_testFixture)).Object.FirstOrDefault();
            tp.Position = 3;
            var team = (await TeamsMethods.AddNewTeamToDB(_testFixture)).Object.FirstOrDefault();
            tp.Team = team;
            var result = await _testFixture.SendAsync(new UpdateTournamentPositionCommand(0, tp));

            var error = "No such Tournament Position Exists!";
            Assert.False(result.Succeeded);
            Assert.Null(result.Object);
            Assert.Equal(error, result.ErrorMessages.FirstOrDefault());
        }

        [Fact]
        public async Task TeamIsNull()
        {
            var tp = (await TournamentPostionsMethods.AddNewTournamentPosition(_testFixture)).Object.FirstOrDefault();
            tp.Position = 3;
            var team = (await TeamsMethods.AddNewTeamToDB(_testFixture)).Object.FirstOrDefault();
            tp.Team = null;
            var result = await _testFixture.SendAsync(new UpdateTournamentPositionCommand(tp.Id, tp));

            var error = "Team or Tournament for the Tournament Position Cannot be empty!";
            Assert.False(result.Succeeded);
            Assert.Null(result.Object);
            Assert.Equal(error, result.ErrorMessages.FirstOrDefault());
        }

        [Fact]
        public async Task TournamentPositionIdIsWrong()
        {
            var tp = (await TournamentPostionsMethods.AddNewTournamentPosition(_testFixture)).Object.FirstOrDefault();
            var newTP = (await TournamentPostionsMethods.AddNewTournamentPosition(_testFixture)).Object.FirstOrDefault();
            tp.Position = 3;
            var team = (await TeamsMethods.AddNewTeamToDB(_testFixture)).Object.FirstOrDefault();
            tp.Team = team;
            var result = await _testFixture.SendAsync(new UpdateTournamentPositionCommand(newTP.Id, tp));

            var error = "Trying to update the wrong Tournament Position!";
            Assert.False(result.Succeeded);
            Assert.Null(result.Object);
            Assert.Equal(error, result.ErrorMessages.FirstOrDefault());
        }
    }
}
