using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class TeamScore: AuditableEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Team Team { get; set; }

        public int Score { get; set; }
        [Required]
        public Match Match { get; set; }
    }
}
