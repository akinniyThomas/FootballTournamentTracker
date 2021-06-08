using Application.Models.TeamScores.Commands;
using Application.ViewModels;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballTorunament.Tests.IntegrationTests.Methods
{
    public class TeamScoresMethods
    {
        public async static Task<AnObjectResult<TeamScore>> AddNewTeamScore(Testing testFixture)
        {
            var team = (await TeamsMethods.AddNewTeamToDB(testFixture)).Object.FirstOrDefault();
            var match = (await MatchesMethods.AddNewMatch(testFixture)).Object.FirstOrDefault();
            TeamScore score = new()
            {
                Score = 30,
                Team = team,
                Match = match
            };

            return await testFixture.SendAsync(new AddTeamScoreCommand(score));
        }

        public async static Task<List<TeamScore>> AddManyTeamScores(Testing testFixture) => new List<TeamScore>()
        {
            (await AddNewTeamScore(testFixture)).Object.FirstOrDefault(),
            (await AddNewTeamScore(testFixture)).Object.FirstOrDefault(),
            (await AddNewTeamScore(testFixture)).Object.FirstOrDefault(),
            (await AddNewTeamScore(testFixture)).Object.FirstOrDefault()
        };
    }
}
