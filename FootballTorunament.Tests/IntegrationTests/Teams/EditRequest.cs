using Application.Models.Teams.Commands;
using Application.Models.Teams.Queries;
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
    public class EditRequest //: IClassFixture<Testing>
    {
        private readonly Testing _testFixture;

        public EditRequest(Testing testFixture)
        {
            _testFixture = testFixture;
        }

        [Fact]
        public async Task CanEdit()
        {
            var team = (await TeamsMethods.AddNewTeamToDB(_testFixture)).Object.FirstOrDefault();
            var newTeamName = "New Team Name";
            team.TeamName = newTeamName;
            var result = await _testFixture.SendAsync(new UpdateTeamCommand(team.Id, team));

            Assert.True(result.Succeeded);
            Assert.Equal("", result.ErrorMessages.LastOrDefault());
            Assert.NotNull(result.Object);
            Assert.NotEmpty(result.Object);
            Assert.Equal(newTeamName, result.Object.FirstOrDefault().TeamName);
            Assert.Single(result.Object);

            var findTeam = await _testFixture.SendAsync(new GetOneTeamQuery(team.Id));
            var findTeamObject = findTeam.Object?.FirstOrDefault();

            Assert.True(findTeam.Succeeded);
            Assert.NotNull(findTeam.Object);
            Assert.NotEmpty(findTeam.Object);
            Assert.Single(findTeam.Object);
            Assert.Equal(newTeamName, findTeamObject.TeamName);
        }

        [Fact]
        public async Task TeamIsNull()
        {
            var error = "No Team with given parameter exist! Refresh an try again!!";

            var team = (await TeamsMethods.AddNewTeamToDB(_testFixture)).Object.FirstOrDefault();
            var newTeamName = "New Team Name";
            team.TeamName = newTeamName;
            var result = await _testFixture.SendAsync(new UpdateTeamCommand(team.Id, null));

            Assert.False(result.Succeeded);
            Assert.Equal(error, result.ErrorMessages.LastOrDefault());
            Assert.Null(result.Object);
        }

        [Fact]
        public async Task TeamIdIsWrong()
        {
            var error = "No Team with given parameter exist! Refresh an try again!!";

            var team = (await TeamsMethods.AddNewTeamToDB(_testFixture)).Object.FirstOrDefault();
            var newTeamName = "New Team Name";
            team.TeamName = newTeamName;
            var result = await _testFixture.SendAsync(new UpdateTeamCommand(0, team));

            Assert.False(result.Succeeded);
            Assert.Equal(error, result.ErrorMessages.LastOrDefault());
            Assert.Null(result.Object);
        }

        [Fact]
        public async Task TeamIdIsNotTeamId()
        {
            var error = "Trying to update wrong Team";

            var team = (await TeamsMethods.AddNewTeamToDB(_testFixture)).Object.FirstOrDefault();
            var anotherTeam = (await TeamsMethods.AddNewTeamToDB(_testFixture)).Object.FirstOrDefault();
            var newTeamName = "New Team Name";
            team.TeamName = newTeamName;
            var result = await _testFixture.SendAsync(new UpdateTeamCommand(anotherTeam.Id, team));

            Assert.False(result.Succeeded);
            Assert.Equal(error, result.ErrorMessages.LastOrDefault());
            Assert.Null(result.Object);
        }
    }
}
