using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class TournamentPosition: AuditableEntity
    {
        public int Id { get; set; }
        public Tournament Tournament { get; set; }
        public int Position { get; set; }
    }
}
