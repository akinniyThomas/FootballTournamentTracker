using Domain.Models;
using Domain.Validations.TournamentValidations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FootballTorunament.Tests.UnitTests
{
    public class TournamentFinishDateAfterStartDateTest
    {
        [Fact]
        public void TournamentIsNull() => Assert.False(FinishDateAfterStartDate.IsFinishedDateBeforeStartDate(null));

        [Fact]
        public void TournamentFinishedDateIsNull() => Assert.False(FinishDateAfterStartDate.IsFinishedDateBeforeStartDate(new Tournament() { DateFinished = null, DateStarted = DateTime.Now }));

        [Fact]
        public void TournamentStartDateIsNull() => Assert.False(FinishDateAfterStartDate.IsFinishedDateBeforeStartDate(new Tournament() { DateFinished = DateTime.Now, DateStarted = null }));

        [Fact]
        public void TournamentStartDateIsAfterFinishedDate() => Assert.True(FinishDateAfterStartDate.IsFinishedDateBeforeStartDate(new Tournament() { DateFinished = DateTime.Now, DateStarted = DateTime.Now.AddDays(4) }));

        [Fact]
        public void TournamentStartDateIsBeforeFinishedDate() => Assert.False(FinishDateAfterStartDate.IsFinishedDateBeforeStartDate(new Tournament() { DateFinished = DateTime.Now.AddDays(4), DateStarted = DateTime.Now }));

        [Fact]
        public void TournamentStartDateIsEqualToFinishDate() => Assert.False(FinishDateAfterStartDate.IsFinishedDateBeforeStartDate(new Tournament() { DateFinished = DateTime.Now, DateStarted = DateTime.Now }));
    }
}
