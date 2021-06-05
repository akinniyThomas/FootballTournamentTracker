using Application.Models.Matches.Commands;
using Application.ViewModels;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballTorunament.Tests.IntegrationTests.Methods
{
    public class MatchesMethods
    {
        public async static Task<AnObjectResult<Match>> AddNewMatch(Testing _testFixture)
        {
            var tournament = (await TournamentsMethods.AddTournament(_testFixture)).Object.FirstOrDefault();
            Match match = new()
            {
                Tournament = tournament,
                MatchDay = DateTime.Today.AddDays(3),
                Round = 4
            };

            return await _testFixture.SendAsync(new AddMatchCommand(match));
        }

        public async static Task<List<Match>> AddManyNewMatches(Testing testFixture) => new List<Match>()
        {
            (await AddNewMatch(testFixture)).Object.FirstOrDefault(),
            (await AddNewMatch(testFixture)).Object.FirstOrDefault(),
            (await AddNewMatch(testFixture)).Object.FirstOrDefault(),
            (await AddNewMatch(testFixture)).Object.FirstOrDefault()
        };
    }
}
