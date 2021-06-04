using Application.Models.Tournaments.Commands;
using Domain.Enums;
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
    public class EditRequest
    {
        private readonly Testing _testFixture;

        public EditRequest(Testing testFixture)
        {
            _testFixture = testFixture;
        }

        [Fact]
        public async Task CanEditTournament()
        {
            var tournament = (await TournamentsMethods.AddTournament(_testFixture)).Object.FirstOrDefault();

            var tournamentString = "A New Tournament";
            tournament.TournamentSex = Sex.Male;
            tournament.TournamentName = tournamentString;

            var result = await _testFixture.SendAsync(new UpdateTournamentCommand(tournament.Id, tournament));

            Assert.True(result.Succeeded);
            Assert.NotNull(result.Object);
            Assert.NotEmpty(result.Object);
            Assert.Single(result.Object);
            Assert.Equal("", result.ErrorMessages.LastOrDefault());

            var resultObject = result.Object.FirstOrDefault();

            Assert.Equal(Sex.Male, resultObject.TournamentSex);
            Assert.Equal(tournamentString, resultObject.TournamentName);
        }

        [Fact]
        public async Task WrongIDGiven()
        {
            var tournament = (await TournamentsMethods.AddTournament(_testFixture)).Object.FirstOrDefault();
            var tournamentWrongId = (await TournamentsMethods.AddTournament(_testFixture)).Object.FirstOrDefault().Id;
            var error = "The Tournament you are trying to update is wrong";
            var tournamentString = "A New Tournament";
            tournament.TournamentSex = Sex.Male;
            tournament.TournamentName = tournamentString;

            var result = await _testFixture.SendAsync(new UpdateTournamentCommand(tournamentWrongId, tournament));

            Assert.False(result.Succeeded);
            Assert.Null(result.Object);
            Assert.Equal(error, result.ErrorMessages.LastOrDefault());
        }

        [Fact]
        public async Task TournamentIsNull()
        {
            var tournament = (await TournamentsMethods.AddTournament(_testFixture)).Object.FirstOrDefault();
            var error = "No such tournament exist, Please refresh and try again!";

            var result = await _testFixture.SendAsync(new UpdateTournamentCommand(tournament.Id, null));

            Assert.False(result.Succeeded);
            Assert.Null(result.Object);
            Assert.Equal(error, result.ErrorMessages.LastOrDefault());
        }

        [Fact]
        public async Task TournamentIdDoesntExist()
        {
            var tournament = (await TournamentsMethods.AddTournament(_testFixture)).Object.FirstOrDefault();
            var error = "No such tournament exist, Please refresh and try again!";

            var result = await _testFixture.SendAsync(new UpdateTournamentCommand(0, tournament));

            Assert.False(result.Succeeded);
            Assert.Null(result.Object);
            Assert.Equal(error, result.ErrorMessages.LastOrDefault());
        }
    }
}
