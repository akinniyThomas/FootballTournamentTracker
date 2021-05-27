using Application.ViewModels;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballTracker.ViewModels
{
    public class UserPlayerViewModel
    {
        public Player Player { get; set; }
        public UserViewModel User { get; set; }
    }
}
