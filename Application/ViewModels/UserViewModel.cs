using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class UserViewModel
    {
        public string UserName { get; set; }
        [EmailAddress]
        public string EmailAddress { get; set; }
        
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string PhoneNumber { get; set; }

        public UserViewModel(string userName, string emailAddress, string password, string confirmPassword, string phoneNumber)
        {
            UserName = userName;
            EmailAddress = emailAddress;
            PhoneNumber = phoneNumber;
            if (password == confirmPassword) Password = password;
            else Password = "";
            ConfirmPassword = confirmPassword;
        }
    }
}
