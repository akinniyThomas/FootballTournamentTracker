using Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Validations.TournamentValidations
{
    public class FinishDateAfterStartDate:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var tournament = validationContext.ObjectInstance as Tournament;
            if (IsFinishedDateBeforeStartDate(tournament))
                return new ValidationResult("You cannot finish before the tournament has begun");
            return ValidationResult.Success;
        }

        public static bool IsFinishedDateBeforeStartDate(Tournament tournament) => tournament != null && tournament.DateFinished != null && tournament.DateStarted != null && tournament.DateFinished.Value.Date < tournament.DateStarted.Value.Date;
    }
}
