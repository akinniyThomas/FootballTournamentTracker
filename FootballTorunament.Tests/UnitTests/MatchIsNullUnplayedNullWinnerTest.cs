using Domain.Models;
using Domain.Validations.MatchValidations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FootballTorunament.Tests.UnitTests
{
    public class MatchIsNullUnplayedNullWinnerTest
    {
        [Fact]
        public void PlayedIsTrue() => Assert.False(NoWinnerIfMatchNotPlayed.IsMatchNullUnplayedNullWinner(new Match() { Played = true, MatchWinner = new Team() { } }));

        [Fact]
        public void MatchIsNull() => Assert.False(NoWinnerIfMatchNotPlayed.IsMatchNullUnplayedNullWinner(null));

        [Fact]
        public void MatchWinnerIsNull() => Assert.False(NoWinnerIfMatchNotPlayed.IsMatchNullUnplayedNullWinner(new Match() { Played = false, MatchWinner = null }));

        [Fact]
        public void MatchIsNotNullPlayedIsFalseWinnerIsNotNull() => Assert.True(NoWinnerIfMatchNotPlayed.IsMatchNullUnplayedNullWinner(new Match() { Played = false, MatchWinner = new Team() }));
    }
}
