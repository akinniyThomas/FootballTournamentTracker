using Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Validations.TournamentValidations
{
    public class CantExceedNumberOfTeamsInTournament:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var tournament = validationContext.ObjectInstance as Tournament;
            if (tournament != null && tournament.NumberOfTeamsInTournament != tournament.TeamsInTournament.Count)
                return new ValidationResult($"Number of Teams in Tournament - {tournament.NumberOfTeamsInTournament} must correspond with the number of Teams to be added to tournament - {tournament.TeamsInTournament.Count}");
            return ValidationResult.Success;
        }

        public static bool NumberOfTeamsInTournamentDoesNotMatchTeamsInTournament(Tournament tournament) => tournament != null && tournament.NumberOfTeamsInTournament != tournament.TeamsInTournament.Count;
    }
}
