using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class UserViewModel
    {
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }

        public UserViewModel(string userName, string emailAddress, string password, string phoneNumber)
        {
            UserName = userName;
            EmailAddress = emailAddress;
            Password = password;
            PhoneNumber = phoneNumber;
        }
    }
}
