using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;


namespace EventFeedbackAPI.Application.dto
{
    public class FeedbackDtoOut
    {

        public int Id { get; set; }
        public int IdEvent { get; set; }
        public int IdParticipant { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Comment { get; set; }

        public EventDto EventDto { get; set; }
        public ParticipantDto ParticipantDto { get; set; }

    }
}
