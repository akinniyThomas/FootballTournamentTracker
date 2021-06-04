using Application.Models.Tournaments.Commands;
using Domain.Enums;
using Domain.Models;
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
    public class AddRequest
    {
        private readonly Testing _testFixture;

        public AddRequest(Testing testFixture)
        {
            _testFixture = testFixture;
        }

        [Fact]
        public async Task CanAddTournament()
        {
            var result = await TournamentsMethods.AddTournament(_testFixture);

            Assert.True(result.Succeeded);
            Assert.NotNull(result);
            Assert.NotNull(result.Object);
            Assert.NotEmpty(result.Object);
            Assert.Single(result.Object);

            var resultObject = result.Object.FirstOrDefault();
            Assert.Equal(Sex.Both, resultObject.TournamentSex);
            Assert.Equal(4, resultObject.NumberOfTeamsInTournament);
            Assert.Equal(30000, resultObject.RegistrationFee);
        }

        [Fact]
        public async Task TournamentIsNull()
        {
            var result = await _testFixture.SendAsync(new AddTournamentCommand(null));
            var error = "Tournament is empty!";
            Assert.False(result.Succeeded);
            Assert.Null(result.Object);
            Assert.Equal(error, result.ErrorMessages.FirstOrDefault());
        }
    }
}
