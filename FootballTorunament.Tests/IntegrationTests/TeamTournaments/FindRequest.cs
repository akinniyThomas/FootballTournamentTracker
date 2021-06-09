using Application.Models.TeamTournaments.Queries;
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
    public class FindRequest
    {
        private readonly Testing _testFixture;

        public FindRequest(Testing testFixture)
        {
            _testFixture = testFixture;
        }

        [Fact]
        public async Task CanGetTeamTournaments()
        {
            var tts = await TeamTournamentsMethods.AddManyTeamTournaments(_testFixture);


            var result = await _testFixture.SendAsync(new GetTeamTournamentsQuery());

            Assert.True(result.Succeeded);
            Assert.NotNull(result.Object);
            Assert.NotEmpty(result.Object);
            Assert.Equal("", result.ErrorMessages.FirstOrDefault());

            var resultObject = result.Object;
            foreach (var tt in tts)
            {
                Assert.Contains(tt.TeamId, resultObject.Select(x => x.TeamId));
                Assert.Contains(tt.TournamentId, resultObject.Select(x => x.TournamentId));
            }
        }

        [Fact]
        public async Task CanGetOneTeamTournaments()
        {
            var tt = (await TeamTournamentsMethods.AddNewTeamTournament(_testFixture)).Object.FirstOrDefault();

            var result = await _testFixture.SendAsync(new GetOneTeamTournamentQuery(tt.TeamId, tt.TournamentId));

            Assert.True(result.Succeeded);
            Assert.NotNull(result.Object);
            Assert.NotEmpty(result.Object);
            Assert.Equal("", result.ErrorMessages.FirstOrDefault());

            var resultObject = result.Object;
            Assert.Contains(tt.TeamId, resultObject.Select(x => x.TeamId));
            Assert.Contains(tt.TournamentId, resultObject.Select(x => x.TournamentId));
        }

        [Fact]
        public async Task TeamTournamentIsNull()
        {
            var result = await _testFixture.SendAsync(new GetOneTeamTournamentQuery(0, 0));
            var error = "No such TeamTournament Exists!";
            Assert.False(result.Succeeded);
            Assert.Null(result.Object);
            Assert.Equal(error,result.ErrorMessages.FirstOrDefault());
        }
    }
}
