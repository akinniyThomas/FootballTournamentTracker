using Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Validations.TournamentValidations
{
    class NoWinnerUntilTournamentFinished:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var tournament = validationContext.ObjectInstance as Tournament;
            if (tournament != null && tournament.DateFinished == null && tournament.TournamentWinner != null)
                return new ValidationResult("There Can't be a Winner Until the Tournament is Finished");
            return ValidationResult.Success;
        }
    }
}
