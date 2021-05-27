using Domain.Enums;
using Domain.Validations.TournamentValidations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Tournament: AuditableEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [UniqueTournamentName]
        public string TournamentName { get; set; }
        //[Required]
        //public int TournamentSize { get; set; }
        [Required]
        public decimal RegistrationFee { get; set; }

        public ICollection<Prize> Prizes { get; set; }
        [Required]
        public Sex TournamentSex { get; set; }
        [Required]
        [TeamSizeMustBeGreaterThanPlayersOnField]
        public int MaxTeamSize { get; set; }
        [Required]
        [TeamSizeMustBeGreaterThanPlayersOnField]
        public int MaxPlayersOnField { get; set; }
        [Required]
        [FinishDateAfterStartDate]
        public DateTime? DateStarted { get; set; }
        [FinishDateAfterStartDate]
        public DateTime? DateFinished { get; set; }
        [Required]
        [TotalTeamsMustBeInMultiples]
        public int NumberOfTeamsInTournament { get; set; }
        [NoWinnerUntilTournamentFinished]
        public Team TournamentWinner { get; set; }
        [NoRunnerUpUntilTournamentFinished]
        public Team TournamentRunnerUp { get; set; }

        [Required]
        [CantExceedNumberOfTeamsInTournament]
        public ICollection<TeamTournament> TeamsInTournament { get; set; }
    }
}
