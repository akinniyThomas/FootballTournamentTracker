using Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Validations.TeamValidations
{
    public class CaptainMustAPlayer:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var team = validationContext.ObjectInstance as Team;
            if (team.IsCaptainInThisTeam())
                return new ValidationResult("Captain Must be a player within the Team");
            return ValidationResult.Success;
        }
    }

    public static class IsCaptainInTeamExtension
    {
        public static bool IsCaptainInThisTeam(this Team team) => team != null && team.Players?.FirstOrDefault(t => t.Id == team.Captain?.Id) != null;
    }
}
