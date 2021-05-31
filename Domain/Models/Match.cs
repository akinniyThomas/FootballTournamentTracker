using Domain.Validations.MatchValidations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Match: AuditableEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Tournament Tournament { get; set; }
        [Required]
        public int Round { get; set; }

        public DateTime MatchDay { get; set; }

        public bool Played { get; set; }
        //[Required]
        public ICollection<TeamScore> TeamsScores { get; set; }
        [NoWinnerIfMatchNotPlayed]
        public Team MatchWinner { get; set; }
    }
}
