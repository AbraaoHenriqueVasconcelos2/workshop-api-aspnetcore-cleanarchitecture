using System;
using System.Collections.Generic;

#nullable disable

namespace Provisorio.Entities
{
    public partial class Feedback
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public int ParticipantId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Comment { get; set; }

        public virtual Event Event { get; set; }
        public virtual Participant Participant { get; set; }
    }
}
