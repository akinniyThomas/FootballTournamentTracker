using Application.Interfaces.Context;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballTracker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamController:ControllerBase
    {
        private readonly ITournamentDbContext _tournamentContext;
        private readonly UserManager<IdentityUser> _userManager;

        public TeamController(ITournamentDbContext tournamentContext, UserManager<IdentityUser> userManager)
        {
            _tournamentContext = tournamentContext;
            _userManager = userManager;
        }

        [HttpGet("{id}")]
        public async Task<IEnumerable<Team>> Get(int id)
        {
            Team team = new()
            {
                TeamName = $"TeamName - {id}"
            };

            await _tournamentContext.Teams.AddAsync(team);
           await  _tournamentContext.SaveChangesAsync(new System.Threading.CancellationToken());

            IdentityUser identityUser = new()
            {
                Email = "email@email.eamil",
                UserName = "email@email.eamil",
                PhoneNumber = "PhoneNumber11"
            };

            var result = await _userManager.CreateAsync(identityUser, "Pass123$!");
            if (result.Succeeded) ;
            var tt = _tournamentContext.Teams.FirstOrDefault();

            Player player1 = new()
            {
                Age = 12,
                ApplicationUserId = identityUser.Id,
                DOB = DateTime.Now,
                PlayerName = "PlayerName-",
                PlayerSex = Domain.Enums.Sex.Both,
                PlayerTeam = tt
            };

            await _tournamentContext.Players.AddAsync(player1);
            await _tournamentContext.SaveChangesAsync(new System.Threading.CancellationToken());

            return _tournamentContext.Teams;
        }
    }
}
