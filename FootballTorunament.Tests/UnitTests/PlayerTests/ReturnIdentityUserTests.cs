using Application.ViewModels;
using Domain.Models;
using Infrastructure.DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FootballTorunament.Tests.UnitTests.PlayerTests
{
    public class ReturnIdentityUserTests
    {
        [Theory]
        [InlineData("userName", "emailAddress", "passwod", "passwod", "phoneNumber")]
        [InlineData("", "", "", "","")]
        public void CanReturnIdentityUser(params string[] values)
        {
            var user = PlayerDA.ReturnIdentityUser(new UserViewModel(values[0], values[1], values[2], values[3], values[4]));

            Assert.Equal(values[0],user.UserName);
            Assert.Equal(values[1], user.Email);
            Assert.Equal(values[4], user.PhoneNumber);
        }
    }
}
