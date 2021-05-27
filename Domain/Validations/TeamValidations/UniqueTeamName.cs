using Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Validations.TeamValidations
{
    public class UniqueTeamName:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var team = validationContext.ObjectInstance as Team;
            //if(team!=null)//check to see if the teamName exist in DB if it does reject it
            return ValidationResult.Success;
        }
    }
}
