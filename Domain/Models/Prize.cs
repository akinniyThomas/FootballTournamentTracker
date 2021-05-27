using Domain.Validations.PrizeValidations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Prize: AuditableEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Tournament Tournament { get; set; }
        [Required]
        public int Postion { get; set; }
        [PrizePercentageOrAmount]
        [CantBeLessThanZero]
        public decimal PrizeAmount { get; set; }
        [PrizePercentageOrAmount]
        [CantBeLessThanZero]
        public decimal PrizePercentage { get; set; }
    }
}
