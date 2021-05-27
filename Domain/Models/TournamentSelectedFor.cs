using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class TournamentSelectedFor: AuditableEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Player Player { get; set; }
        [Required]
        public Tournament Tournament { get; set; }
        [Required]
        public bool IsSelected { get; set; } = false;
    }
}
