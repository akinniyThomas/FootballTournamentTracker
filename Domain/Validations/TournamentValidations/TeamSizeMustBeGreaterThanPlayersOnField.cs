using Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Validations.TournamentValidations
{
    public class TeamSizeMustBeGreaterThanPlayersOnField:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var tournament = validationContext.ObjectInstance as Tournament;
            if (tournament != null && tournament.MaxPlayersOnField > tournament.MaxTeamSize)
                return new ValidationResult("The Maximum Team Size Cannot be lesser than the Maximum Allowed Players on Field");
            return ValidationResult.Success;
        }
    }
}
