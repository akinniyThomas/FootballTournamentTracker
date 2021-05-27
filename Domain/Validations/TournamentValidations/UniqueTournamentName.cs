using Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Validations.TournamentValidations
{
    class UniqueTournamentName:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var tournament = validationContext.ObjectInstance as Tournament;
            //if tournament.TournamentName already exist reject it
            return ValidationResult.Success;
        }
    }
}
