using Domain.Enums;
using Domain.Validations.PlayerValidations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Player: AuditableEntity
    {
        [Key]
        public int Id { get; set; }
        public string PlayerName { get; set; }
        public Sex PlayerSex { get; set; }
        public int Age { get; set; }
        public DateTime DOB { get; set; }
        public ICollection<TournamentSelectedFor> IsSelected { get; set; }
        //public Team Player_sTeam { get; set; }
        public bool IsRetired { get; set; } = false;
        [Required]
        [ApplicationUserMustBeIncluded]
        public string ApplicationUserId { get; set; }
    }
}
