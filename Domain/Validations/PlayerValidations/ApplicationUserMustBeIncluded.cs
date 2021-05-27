using Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Validations.PlayerValidations
{
    public class ApplicationUserMustBeIncluded:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var player = validationContext.ObjectInstance as Player;
            if (IsNullEmptyORWhiteSpaced(player.ApplicationUserId))
                return new ValidationResult("ApplicationUserId must be included");
            return ValidationResult.Success;
        }

        public bool IsNullEmptyORWhiteSpaced(string str)
        {
            return string.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str);
        }
    }
}
