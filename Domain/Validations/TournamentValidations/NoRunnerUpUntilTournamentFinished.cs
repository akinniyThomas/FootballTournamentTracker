using Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Validations.TournamentValidations
{
    class NoRunnerUpUntilTournamentFinished:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var tournament = validationContext.ObjectInstance as Tournament;
            if (tournament.IsNotFinishedTournament(tournament.TournamentRunnerUp))
                return new ValidationResult("There Can't be a RunnerUp Until the Tournament is Finished");
            return ValidationResult.Success;
        }
    }

    public static class IsNotFinishedExtension
    {
        public static bool IsNotFinishedTournament(this Tournament tournament, Team team) => tournament != null && tournament.DateFinished == null && team != null;
    }
}
