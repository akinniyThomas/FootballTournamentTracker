using Domain.Models;
using Domain.Validations.PrizeValidations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FootballTorunament.Tests.UnitTests
{
    public class PrizeIsNotNullWithAmountAndPercentageAboveZeroTest
    {
        [Fact]
        public void PrizeIsNull() => Assert.False(PrizePercentageOrAmount.PrizeIsNotNullWithAmountAndPercentageAboveZero(null));

        [Fact]
        public void PrizeAmountIsAboveZeroPercentageIsNot() => Assert.False(PrizePercentageOrAmount.PrizeIsNotNullWithAmountAndPercentageAboveZero(new Prize() { PrizeAmount = 4000, PrizePercentage = 0 }));

        [Fact]
        public void PrizePercentageIsAboveZeroAmountIsNot() => Assert.False(PrizePercentageOrAmount.PrizeIsNotNullWithAmountAndPercentageAboveZero(new Prize() { PrizeAmount = 0, PrizePercentage = 5 }));

        [Fact]
        public void PrizeIsNotNullAmountandPercentageAboveZero() => Assert.True(PrizePercentageOrAmount.PrizeIsNotNullWithAmountAndPercentageAboveZero(new Prize() { PrizeAmount = 4000, PrizePercentage = 5 }));
    }
}
