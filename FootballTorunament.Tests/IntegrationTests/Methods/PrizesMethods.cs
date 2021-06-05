using Application.Models.Prizes.Commands;
using Application.ViewModels;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballTorunament.Tests.IntegrationTests.Methods
{
    public class PrizesMethods
    {
        public async static Task<AnObjectResult<Prize>> AddNewPrize(Testing _testFixture)
        {
            var tournament = (await TournamentsMethods.AddTournament(_testFixture)).Object.FirstOrDefault();
            Prize prize = new()
            {
                Postion = 1,
                PrizePercentage = 12,
                Tournament = tournament
            };

            return await _testFixture.SendAsync(new AddPrizeCommand(prize));
        }

        public async static Task<List<Prize>> AddManyPrizes(Testing testFixture) => new List<Prize>()
        {
            (await AddNewPrize(testFixture)).Object.FirstOrDefault(),
            (await AddNewPrize(testFixture)).Object.FirstOrDefault(),
            (await AddNewPrize(testFixture)).Object.FirstOrDefault(),
            (await AddNewPrize(testFixture)).Object.FirstOrDefault()
        };
    }
}
