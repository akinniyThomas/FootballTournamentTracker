using Application.Models.Players.Queries;
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
    public class FindRequest//:IClassFixture<Testing>
    {
        private readonly Testing _testFixture;

        public FindRequest(Testing testFixture)
        {
            _testFixture = testFixture;
        }
        
        [Fact]
        public async Task CanGetAllTeams()
        {
            var teams = await TeamsMethods.AddManyTeamsToDB(_testFixture);

            var result = await _testFixture.SendAsync(new GetAllTeamsQuery());
            var resultObject = result.Object;

            Assert.True(result.Succeeded);
            Assert.NotNull(resultObject);
            Assert.NotEmpty(resultObject);
            Assert.Contains(teams[0].Id, resultObject.Select(x => x.Id));
            Assert.Contains(teams[1].Id, resultObject.Select(x => x.Id));
            Assert.Contains(teams[2].Id, resultObject.Select(x => x.Id));
            Assert.Contains(teams[3].Id, resultObject.Select(x => x.Id));

            var team = await TeamsMethods.AddNewTeamToDB(_testFixture);

            Assert.True(team.Succeeded);
            Assert.DoesNotContain(team.Object.FirstOrDefault().Id, resultObject.Select(x => x.Id));
        }

        [Fact]
        public async Task CanGetOneTeam()
        {
            var team = (await TeamsMethods.AddNewTeamToDB(_testFixture)).Object.FirstOrDefault();

            var result = await _testFixture.SendAsync(new GetOneTeamQuery(team.Id));
            var teamDetails = result.Object;

            Assert.True(result.Succeeded);
            Assert.NotNull(result);
            Assert.NotNull(teamDetails);
            Assert.NotEmpty(teamDetails);
            Assert.Single(teamDetails);
            Assert.Equal(team.TeamName, teamDetails.First().TeamName);
            Assert.Equal(team.Id, teamDetails.FirstOrDefault().Id);
        }

        [Fact(Skip ="Undecided if i should put in team or player")]
        public async Task CanGetCaptain()
        {
            var team = (await TeamsMethods.AddNewTeamToDB(_testFixture)).Object.FirstOrDefault();

            var result = await _testFixture.SendAsync(new GetCaptainQuery(team.Id));
            var playerDetails = result.Object;

            var allPlayersInTeam = (await _testFixture.SendAsync(new GetAllPlayersQuery())).Object.Where(x => x.PlayerTeam.Id == team.Id);

            Assert.True(result.Succeeded);
            Assert.NotNull(result);
            Assert.NotNull(playerDetails);
            Assert.NotEmpty(playerDetails);
            Assert.Single(playerDetails);
            Assert.Contains(playerDetails.FirstOrDefault().Id, allPlayersInTeam.Select(x => x.Id));
            Assert.Equal(allPlayersInTeam.FirstOrDefault(x => x.IsCaptain).PlayerName, playerDetails.FirstOrDefault().PlayerName);
            //Assert.Equal(team.Captain.PlayerName, playerDetails.FirstOrDefault().PlayerName);
        }

        [Fact(Skip = "Undecided if i should put in team or player")]
        public async Task CanGetPlayersInTeam()
        {
            var team = (await TeamsMethods.AddNewTeamToDB(_testFixture)).Object.FirstOrDefault();

            var result = await _testFixture.SendAsync(new Application.Models.Teams.Queries.GetPlayersInTeamQuery(team.Id));
            var playerDetails = result.Object;

            Assert.True(result.Succeeded);
            Assert.NotNull(result);
            Assert.NotNull(playerDetails);
            Assert.NotEmpty(playerDetails);
            Assert.Single(playerDetails);

            var allPlayers = await _testFixture.SendAsync(new GetAllPlayersQuery());

            foreach (var player in allPlayers.Object.Where(x => x.PlayerTeam.Id == team.Id))
                Assert.Contains(player.Id, playerDetails.Select(x => x.Id));
        }

        [Fact(Skip = "Tournaments Not yet Created")]
        public async Task CanGetPastTournaments()
        {

            var team = (await TeamsMethods.AddNewTeamToDB(_testFixture)).Object.FirstOrDefault();

            var result = await _testFixture.SendAsync(new GetPastTournamentsQuery(team.Id));
            var tournamentPositions = result.Object;

            Assert.True(result.Succeeded);
            Assert.NotNull(result);
            Assert.NotNull(tournamentPositions);
            Assert.NotEmpty(tournamentPositions);
            //Assert.Contains(team.PastTournaments.FirstOrDefault().Id, tournamentPositions.Select(x => x.Id));
            //var tt = team.PastTournaments.FirstOrDefault().Id;
            //Assert.Equal(team.PastTournaments.FirstOrDefault(x => x.Id == tt).Position, tournamentPositions.FirstOrDefault(x => x.Id == tt).Position);
        }

        [Fact(Skip = "Tournaments Not yet Created")]
        public async Task CanGetPresentTournaments()
        {
            var team = (await TeamsMethods.AddNewTeamToDB(_testFixture)).Object.FirstOrDefault();

            var result = await _testFixture.SendAsync(new GetPresentTournamentsQuery(team.Id));
            var teamTournaments = result.Object;

            Assert.True(result.Succeeded);
            Assert.NotNull(result);
            Assert.NotNull(teamTournaments);
            Assert.NotEmpty(teamTournaments);
            
            //foreach(var tt in team.PresentTournaments)
            //    Assert.Contains(tt.TeamId, teamTournaments.Select(x => x.TeamId));
        }
    }
}
