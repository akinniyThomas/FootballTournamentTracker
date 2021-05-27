using Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Validations.PrizeValidations
{
    public class CantBeLessThanZero:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var prize = validationContext.ObjectInstance as Prize;
            if (prize != null && prize.PrizeAmount.IsLessThanZero())
                return new ValidationResult("Prize Amount is Less Than Zero");
            else if (prize != null && prize.PrizePercentage.IsLessThanZero())
                return new ValidationResult("Prize Percentage is Less Than Zero");
            return ValidationResult.Success;
        }

    }

    public static class LessThanZeroClass
    {
        public static bool IsLessThanZero(this decimal prizeValue) => prizeValue < 0;
    }
}
