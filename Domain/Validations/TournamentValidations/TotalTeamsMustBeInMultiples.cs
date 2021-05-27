using Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Validations.TournamentValidations
{
    public class TotalTeamsMustBeInMultiples:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var tournament = validationContext.ObjectInstance as Tournament;
            if (tournament != null && IsNotAMultiple(tournament.NumberOfTeamsInTournament))
                return new ValidationResult("Total Number of Teams in Tournament must be a proper multiple of 2");
            return ValidationResult.Success;
        }

        public bool IsNotAMultiple(int numberOfTeamsInTournament)
        {
            bool result = false;
            while (numberOfTeamsInTournament > 1)
            {
                var quotient = numberOfTeamsInTournament / 2;
                var remainder = numberOfTeamsInTournament % 2;
                if(remainder != 0)
                {
                    result = true;
                    break;
                }
                numberOfTeamsInTournament = quotient;
            }
            return result;
        }
    }
}
