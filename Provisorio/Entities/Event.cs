using System;
using System.Collections.Generic;

#nullable disable

namespace Provisorio.Entities
{
    public partial class Event
    {
        public Event()
        {
            Feedbacks = new HashSet<Feedback>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Feedback> Feedbacks { get; set; }
    }
}
