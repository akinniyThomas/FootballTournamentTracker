using Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Validations.PrizeValidations
{
    public class PrizePercentageOrAmount:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var prize = validationContext.ObjectInstance as Prize;
            if (PrizeIsNotNullWithAmountAndPercentageAboveZero(prize))
                return new ValidationResult("Prize Amount and Prize Percentage Can't be applied at Same Time");
            return ValidationResult.Success;
        }

        public static bool PrizeIsNotNullWithAmountAndPercentageAboveZero(Prize prize) => prize != null && prize.PrizeAmount > 0 && prize.PrizePercentage > 0;
    }
}
