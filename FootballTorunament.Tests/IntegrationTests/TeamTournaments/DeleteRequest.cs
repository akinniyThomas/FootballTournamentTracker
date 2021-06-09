using Application.Models.TeamTournaments.Commands;
using FootballTorunament.Tests.IntegrationTests.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FootballTorunament.Tests.IntegrationTests.TeamTournaments
{
    [Collection(nameof(Testing))]
    public class DeleteRequest
    {
        private readonly Testing _testFixture;

        public DeleteRequest(Testing testFixture)
        {
            _testFixture = testFixture;
        }

        [Fact]
        public async Task CanDeleteTeamTournament()
        {
            var tt = (await TeamTournamentsMethods.AddNewTeamTournament(_testFixture)).Object.FirstOrDefault();

            var result = await _testFixture.SendAsync(new DeleteTeamTournamentCommand(tt.TeamId, tt.TournamentId));

            Assert.True(result.Succeeded);
            Assert.Null(result.Object);
            Assert.Equal("", result.ErrorMessages.FirstOrDefault());
        }

        [Fact]
        public async Task TeamTournamentIsNull()
        {
            var result = await _testFixture.SendAsync(new DeleteTeamTournamentCommand(0, 0));
            var error = "TeamTournament Doesn't Exist!";
            Assert.False(result.Succeeded);
            Assert.Null(result.Object);
            Assert.Equal(error, result.ErrorMessages.FirstOrDefault());
        }
    }
}
