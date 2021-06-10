using Application.Models.TournamentPositions.Commands;
using Application.ViewModels;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballTorunament.Tests.IntegrationTests.Methods
{
    public class TournamentPostionsMethods
    {
        public static async Task<AnObjectResult<TournamentPosition>> AddNewTournamentPosition(Testing testFixture)
        {
            var tournament = (await TournamentsMethods.AddTournament(testFixture)).Object.FirstOrDefault();
            var team = (await TeamsMethods.AddNewTeamToDB(testFixture)).Object.FirstOrDefault();
            TournamentPosition tp = new()
            {
                Tournament = tournament,
                Team = team,
                Position = 2
            };

            return await testFixture.SendAsync(new AddTournamentPositionCommand(tp));
        }

        public static async Task<List<TournamentPosition>> AddManyTournamentPosition(Testing testFixture) => new List<TournamentPosition>()
        {
            (await AddNewTournamentPosition(testFixture)).Object.FirstOrDefault(),
            (await AddNewTournamentPosition(testFixture)).Object.FirstOrDefault(),
            (await AddNewTournamentPosition(testFixture)).Object.FirstOrDefault(),
            (await AddNewTournamentPosition(testFixture)).Object.FirstOrDefault()
        };
    }
}
