using Domain.Validations.PrizeValidations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FootballTorunament.Tests.UnitTests
{
    public class PrizeCantBeLessThanZero
    {
        [Fact]
        public void PrizeIsLessThanZero() => Assert.True(LessThanZeroClass.IsLessThanZero(-3));

        [Fact]
        public void PrizeIsMoreThanZero() => Assert.False(LessThanZeroClass.IsLessThanZero(3));

        [Fact]
        public void PrizeIsEqualToZero() => Assert.False(LessThanZeroClass.IsLessThanZero(0));
    }
}
