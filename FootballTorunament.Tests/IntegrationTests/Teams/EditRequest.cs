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
    public class EditRequest : IClassFixture<Testing>
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

            var findTeam = await _testFixture.SendAsync(new GetOneTeamQuery(result.Object.FirstOrDefault().Id));
            var findTeamObject = findTeam.Object?.FirstOrDefault();

            Assert.True(findTeam.Succeeded);
            Assert.NotNull(findTeam.Object);
            Assert.NotEmpty(findTeam.Object);
            Assert.Single(findTeam.Object);
            Assert.Equal(newTeamName, findTeamObject.TeamName);
        }
    }
}
