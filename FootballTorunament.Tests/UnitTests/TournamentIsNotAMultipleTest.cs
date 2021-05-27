using Domain.Validations.TournamentValidations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FootballTorunament.Tests.UnitTests
{
    public class TournamentIsNotAMultipleTest
    {
        [Theory]
        [InlineData(3)]
        [InlineData(6)]
        [InlineData(36)]
        [InlineData(96)]
        public void IsNotAMultiple(int value)
        {
            var expected = true;
            var actual = new TotalTeamsMustBeInMultiples().IsNotAMultiple(value);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(2)]
        [InlineData(4)]
        [InlineData(16)]
        [InlineData(128)]
        public void IsAMultiple(int value)
        {
            var expected = true;
            var actual = !new TotalTeamsMustBeInMultiples().IsNotAMultiple(value);
            Assert.Equal(expected, actual);
        }

    }
}
