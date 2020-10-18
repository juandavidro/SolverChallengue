using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolverChallengue.DataAccess.Entities
{
    public class Record
    {
        [Key]
        public Guid RecordId { get; set; }
        [Required]
        public int DocumentId { get; set; }
        public DateTimeOffset ExecDate { get; set; }
    }
}
