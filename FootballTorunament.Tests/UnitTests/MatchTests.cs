using Domain.Models;
using Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FootballTorunament.Tests.UnitTests
{
    [Collection(nameof(Testing))]
    public class MatchTests// : Testing
    {
        private readonly Testing _testing;

        public MatchTests(Testing testing)
        {
            _testing = testing;
        }
        //[Fact]
        //public async Task GetMatches_Works()
        //{
        //    //var match = new MatchDA(_tournamentContext);
        //    //Match m = new() { MatchDay = DateTime.Today, MatchWinner = new Team(), Round = 3, Played = false, Tournament = new (), TeamsScores = new () };
        //    //await _testing.AddAsync<Match>(m);
        //    //var match = await _testing.FindAsync<Match>(9);

        //    Assert.NotNull(null);
        //}

        //[Fact]
        //public async Task GetAnother()
        //{
        //    //Match m = new() { MatchDay = DateTime.Today, MatchWinner = new Team(), Round = 3, Played = false, Tournament = new Tournament(), TeamsScores = new() };
        //    //await _testing.AddAsync<Match>(m);
        //    //var match = await _testing.FindAsync<Match>(9);

        //    Assert.NotNull(null);
        //}

        //[Fact]
        //public async Task GetFinal()
        //{
        //    //Match m = new() { MatchDay = DateTime.Today, MatchWinner = new Team(), Round = 3, Played = false, Tournament = new Tournament(), TeamsScores = new() };
        //    //await _testing.AddAsync<Match>(m);
        //    //var match = await _testing.FindAsync<Match>(9);

        //    Assert.NotNull(null);
        //}
    }
}
