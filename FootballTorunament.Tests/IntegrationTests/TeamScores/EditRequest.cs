using Application.Models.TeamScores.Commands;
using FootballTorunament.Tests.IntegrationTests.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FootballTorunament.Tests.IntegrationTests.TeamScores
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
        public async Task CanUpdateTeamScore()
        {
            var teamScore = (await TeamScoresMethods.AddNewTeamScore(_testFixture)).Object.FirstOrDefault();
            teamScore.Score = 5;
            var newTeam = (await TeamsMethods.AddNewTeamToDB(_testFixture)).Object.FirstOrDefault();
            var newMatch = (await MatchesMethods.AddNewMatch(_testFixture)).Object.FirstOrDefault();

            teamScore.Match = newMatch;
            teamScore.Team = newTeam;

            var result = await _testFixture.SendAsync(new UpdateTeamScoreCommand(teamScore.Id, teamScore));

            Assert.True(result.Succeeded);
            Assert.NotNull(result.Object);
            Assert.NotEmpty(result.Object);
            Assert.Single(result.Object);
            Assert.Equal("", result.ErrorMessages.FirstOrDefault());

            var resultObject = result.Object.FirstOrDefault();
            Assert.Equal(teamScore.Score, resultObject.Score);
            Assert.Equal(teamScore.Match.Id, resultObject.Match.Id);
            Assert.Equal(teamScore.Team.Id, resultObject.Team.Id);
        }

        [Fact]
        public async Task TeamScoreIdIsWrong()
        {
            var teamScore = (await TeamScoresMethods.AddNewTeamScore(_testFixture)).Object.FirstOrDefault();
            teamScore.Score = 5;
            var newTeam = (await TeamsMethods.AddNewTeamToDB(_testFixture)).Object.FirstOrDefault();
            var newMatch = (await MatchesMethods.AddNewMatch(_testFixture)).Object.FirstOrDefault();

            teamScore.Match = newMatch;
            teamScore.Team = newTeam;

            var result = await _testFixture.SendAsync(new UpdateTeamScoreCommand(0, teamScore));

            var error = "No such TeamScore Exists!";
            Assert.False(result.Succeeded);
            Assert.Null(result.Object);
            Assert.Equal(error, result.ErrorMessages.FirstOrDefault());
        }

        [Fact]
        public async Task TeamScoreIsNull()
        {
            var teamScore = (await TeamScoresMethods.AddNewTeamScore(_testFixture)).Object.FirstOrDefault();
            teamScore.Score = 5;
            var newTeam = (await TeamsMethods.AddNewTeamToDB(_testFixture)).Object.FirstOrDefault();
            var newMatch = (await MatchesMethods.AddNewMatch(_testFixture)).Object.FirstOrDefault();

            teamScore.Match = newMatch;
            teamScore.Team = newTeam;

            var result = await _testFixture.SendAsync(new UpdateTeamScoreCommand(teamScore.Id, null));

            var error = "No such TeamScore Exists!";
            Assert.False(result.Succeeded);
            Assert.Null(result.Object);
            Assert.Equal(error, result.ErrorMessages.FirstOrDefault());
        }

        [Fact]
        public async Task UpdateTeamScoreIdIsNotTeamScoreId()
        {
            var teamScore = (await TeamScoresMethods.AddNewTeamScore(_testFixture)).Object.FirstOrDefault();
            teamScore.Score = 5;
            var newTeam = (await TeamsMethods.AddNewTeamToDB(_testFixture)).Object.FirstOrDefault();
            var newMatch = (await MatchesMethods.AddNewMatch(_testFixture)).Object.FirstOrDefault();
            var newTeamScore = (await TeamScoresMethods.AddNewTeamScore(_testFixture)).Object.FirstOrDefault();

            teamScore.Match = newMatch;
            teamScore.Team = newTeam;

            var result = await _testFixture.SendAsync(new UpdateTeamScoreCommand(teamScore.Id, newTeamScore));

            var error = "Trying to update the wrong TeamScore";
            Assert.False(result.Succeeded);
            Assert.Null(result.Object);
            Assert.Equal(error, result.ErrorMessages.FirstOrDefault());
        }
    }
}
