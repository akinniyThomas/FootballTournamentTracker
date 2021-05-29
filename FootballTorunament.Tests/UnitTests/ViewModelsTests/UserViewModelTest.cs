using Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FootballTorunament.Tests.UnitTests.ViewModelsTests
{
    public class UserViewModelTest
    {
        [Theory]
        [InlineData("userName", "email@emailAddress.com", "password", "password", "phoneNumber")]
        [InlineData("", "email@emailAddress.com", "", "", "")]
        public void CanAddUserViewModel(params string[] user)
        {
            var userModel = new UserViewModel(user[0], user[1], user[2], user[3], user[4]);
            Assert.Equal(user[0], userModel.UserName);
            Assert.Equal(user[1], userModel.EmailAddress);
            Assert.Equal(user[2], userModel.Password);
            Assert.Equal(user[3], userModel.ConfirmPassword);
            Assert.Equal(user[4], userModel.PhoneNumber);
        }

        [Fact]
        public void EmailNotRightFormat()
        {
            var userModel = new UserViewModel("userName", "email", "passord", "password", "phoneNumber");
            Assert.Equal("userName", userModel.UserName);
            Assert.Equal("email", userModel.EmailAddress);
            Assert.NotEqual("passord", userModel.Password);
            Assert.Equal("password", userModel.ConfirmPassword);
            Assert.Equal("phoneNumber", userModel.PhoneNumber);
        }

        [Fact]
        public void PasswordNotSameAsConfirmPassword()
        {
            var userModel = new UserViewModel("userName", "email@email.email", "passord", "password1", "phoneNumber");
            Assert.Equal("userName", userModel.UserName);
            Assert.Equal("email@email.email", userModel.EmailAddress);
            Assert.Equal("", userModel.Password);
            Assert.Equal("password1", userModel.ConfirmPassword);
            Assert.Equal("phoneNumber", userModel.PhoneNumber);
        }
    }
}
