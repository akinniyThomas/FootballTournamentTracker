using Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Validations.MatchValidations
{
    public class NoWinnerIfMatchNotPlayed:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var match = validationContext.ObjectInstance as Match;
            if (IsMatchNullUnplayedNullWinner(match))
                return new ValidationResult("There can't be a winner when the match has not been played ");
            return ValidationResult.Success;
        }

        public static bool IsMatchNullUnplayedNullWinner(Match match) => match != null && !match.Played && match.MatchWinner != null;
    }
}
