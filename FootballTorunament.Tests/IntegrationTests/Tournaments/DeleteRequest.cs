using Application.Models.Tournaments.Commands;
using FootballTorunament.Tests.IntegrationTests.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FootballTorunament.Tests.IntegrationTests.Tournaments
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
        public async Task CanDeleteTournament()
        {
            var tournament = (await TournamentsMethods.AddTournament(_testFixture)).Object.FirstOrDefault();

            var deleteTournament = await _testFixture.SendAsync(new DeleteTournamentCommand(tournament.Id));

            Assert.True(deleteTournament.Succeeded);
            Assert.Null(deleteTournament.Object);
            Assert.Equal("", deleteTournament.ErrorMessages.FirstOrDefault());
        }

        [Fact]
        public async Task TournamentDoesNotExist()
        {
            var error = "No such Tournament Exist!";

            var deleteTournament = await _testFixture.SendAsync(new DeleteTournamentCommand(0));

            Assert.False(deleteTournament.Succeeded);
            Assert.Null(deleteTournament.Object);
            Assert.Equal(error, deleteTournament.ErrorMessages.FirstOrDefault());
        }
    }
}
