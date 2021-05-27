using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class TeamTournament: AuditableEntity
    {
        public int TeamId { get; set; }
        public int TournamentId { get; set; }

        public Tournament Tournament { get; set; }
        public Team Team { get; set; }
    }
}
