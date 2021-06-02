using Domain.Validations.TeamValidations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Team: AuditableEntity
    {
        [Key]
        public int Id { get; set; }
        //[Required]
        [UniqueTeamName]
        public string TeamName { get; set; }
        //[Required]
        //public ICollection<Player> Players { get; set; }
        //[Required]
        //[CaptainMustAPlayer]
        //public Player Captain { get; set; }
        //public ICollection<TeamTournament> PresentTournaments { get; set; }
        //public ICollection<TournamentPosition> PastTournaments { get; set; }
    }
}
