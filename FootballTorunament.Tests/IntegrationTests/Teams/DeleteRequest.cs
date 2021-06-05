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
    public class DeleteRequest//:IClassFixture<Testing>
    {
        private readonly Testing _testFixture;

        public DeleteRequest(Testing testFixture)
        {
            _testFixture = testFixture;
        }

        [Fact]
        public async Task CanDeleteTeam()
        {
            var team = await TeamsMethods.AddNewTeamToDB(_testFixture);

            var deleteOutput = await _testFixture.SendAsync(new DeleteTeamCommand(team.Object.FirstOrDefault().Id));

            var findTeam = await _testFixture.SendAsync(new GetOneTeamQuery(team.Object.FirstOrDefault().Id));

            var error = "No Team with given";


            Assert.True(deleteOutput.Succeeded);
            Assert.Null(deleteOutput.Object);
            Assert.Equal("", deleteOutput.ErrorMessages.FirstOrDefault());

            Assert.Null(findTeam.Object);
            Assert.False(findTeam.Succeeded);
            Assert.Matches(error, findTeam.ErrorMessages.LastOrDefault());
        }

        [Fact]
        public async Task TeamIsNull()
        {
            var deleteOutput = await _testFixture.SendAsync(new DeleteTeamCommand(0));

            var error = "No team such team exist, kindly refresh and try again!";


            Assert.False(deleteOutput.Succeeded);
            Assert.Null(deleteOutput.Object);
            Assert.Equal(error, deleteOutput.ErrorMessages.FirstOrDefault());
        }
    }
}
