using Application.Models.TournamentSelectedFors.Commands;
using FootballTorunament.Tests.IntegrationTests.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FootballTorunament.Tests.IntegrationTests.TournamentSelected
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
        public async Task CanUpdateTournamentSelectedFor()
        {
            var tsf = (await TournamentSelectedForsMethods.AddNewTournamentSelectedFor(_testFixture)).Object.FirstOrDefault();
            var tournament = (await TournamentsMethods.AddTournament(_testFixture)).Object.FirstOrDefault();
            var team = (await TeamsMethods.AddNewTeamToDB(_testFixture)).Object.FirstOrDefault();
            var player = (await PlayersMethods.AddNewPlayerToDB(_testFixture, team)).Object.FirstOrDefault();

            tsf.IsSelected = true;
            tsf.Tournament = tournament;
            tsf.Player = player;

            var result = await _testFixture.SendAsync(new UpdateTournamentSelectedForCommand(tsf.Id, tsf));

            Assert.True(result.Succeeded);
            Assert.NotNull(result.Object);
            Assert.NotEmpty(result.Object);
            Assert.Single(result.Object);
            Assert.Equal("", result.ErrorMessages.FirstOrDefault());

            var resultObject = result.Object.FirstOrDefault();
            Assert.Equal(tournament.Id, resultObject.Tournament.Id);
            Assert.Equal(player.Id, resultObject.Player.Id);
            Assert.True(resultObject.IsSelected);
        }

        [Fact]
        public async Task UpdatedTSFIdIsWrong()
        {
            var tsf = (await TournamentSelectedForsMethods.AddNewTournamentSelectedFor(_testFixture)).Object.FirstOrDefault();
            var tournament = (await TournamentsMethods.AddTournament(_testFixture)).Object.FirstOrDefault();
            var team = (await TeamsMethods.AddNewTeamToDB(_testFixture)).Object.FirstOrDefault();
            var player = (await PlayersMethods.AddNewPlayerToDB(_testFixture, team)).Object.FirstOrDefault();

            tsf.IsSelected = true;
            tsf.Tournament = tournament;
            tsf.Player = player;

            var result = await _testFixture.SendAsync(new UpdateTournamentSelectedForCommand(0, tsf));

            var error = "No such TournamentSelectedFor Exists!";

            Assert.False(result.Succeeded);
            Assert.Null(result.Object);
            Assert.Equal(error, result.ErrorMessages.FirstOrDefault());
        }

        [Fact]
        public async Task TournamentSelectedForIsNull()
        {
            var tsf = (await TournamentSelectedForsMethods.AddNewTournamentSelectedFor(_testFixture)).Object.FirstOrDefault();
            var tournament = (await TournamentsMethods.AddTournament(_testFixture)).Object.FirstOrDefault();
            var team = (await TeamsMethods.AddNewTeamToDB(_testFixture)).Object.FirstOrDefault();
            var player = (await PlayersMethods.AddNewPlayerToDB(_testFixture, team)).Object.FirstOrDefault();

            tsf.IsSelected = true;
            tsf.Tournament = tournament;
            tsf.Player = player;

            var result = await _testFixture.SendAsync(new UpdateTournamentSelectedForCommand(tsf.Id, null));

            var error = "No such TournamentSelectedFor Exists!";

            Assert.False(result.Succeeded);
            Assert.Null(result.Object);
            Assert.Equal(error, result.ErrorMessages.FirstOrDefault());
        }

        [Fact]
        public async Task TournamentSelectedForIdIsNotCorrect()
        {
            var tsf = (await TournamentSelectedForsMethods.AddNewTournamentSelectedFor(_testFixture)).Object.FirstOrDefault();
            var tournament = (await TournamentsMethods.AddTournament(_testFixture)).Object.FirstOrDefault();
            var team = (await TeamsMethods.AddNewTeamToDB(_testFixture)).Object.FirstOrDefault();
            var player = (await PlayersMethods.AddNewPlayerToDB(_testFixture, team)).Object.FirstOrDefault();
            var newTsf = (await TournamentSelectedForsMethods.AddNewTournamentSelectedFor(_testFixture)).Object.FirstOrDefault();

            tsf.IsSelected = true;
            tsf.Tournament = tournament;
            tsf.Player = player;

            var result = await _testFixture.SendAsync(new UpdateTournamentSelectedForCommand(tsf.Id, newTsf));

            var error = "Trying to update the wrong TournamentSelectedFor!";

            Assert.False(result.Succeeded);
            Assert.Null(result.Object);
            Assert.Equal(error, result.ErrorMessages.FirstOrDefault());
        }

        [Fact]
        public async Task PlayerIsNull()
        {
            var tsf = (await TournamentSelectedForsMethods.AddNewTournamentSelectedFor(_testFixture)).Object.FirstOrDefault();
            var tournament = (await TournamentsMethods.AddTournament(_testFixture)).Object.FirstOrDefault();

            tsf.IsSelected = true;
            tsf.Tournament = tournament;
            tsf.Player = null;

            var result = await _testFixture.SendAsync(new UpdateTournamentSelectedForCommand(tsf.Id, tsf));

            var error = "Player or Tournament cannot be null!";

            Assert.False(result.Succeeded);
            Assert.Null(result.Object);
            Assert.Equal(error, result.ErrorMessages.FirstOrDefault());
        }

        [Fact]
        public async Task TournamentIsNull()
        {
            var tsf = (await TournamentSelectedForsMethods.AddNewTournamentSelectedFor(_testFixture)).Object.FirstOrDefault();
            var team = (await TeamsMethods.AddNewTeamToDB(_testFixture)).Object.FirstOrDefault();
            var player = (await PlayersMethods.AddNewPlayerToDB(_testFixture, team)).Object.FirstOrDefault();

            tsf.IsSelected = true;
            tsf.Tournament = null;
            tsf.Player = player;

            var result = await _testFixture.SendAsync(new UpdateTournamentSelectedForCommand(tsf.Id, tsf));

            var error = "Player or Tournament cannot be null!";

            Assert.False(result.Succeeded);
            Assert.Null(result.Object);
            Assert.Equal(error, result.ErrorMessages.FirstOrDefault());
        }
    }
}
