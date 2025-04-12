using System;
using System.Collections.Generic;
using EventFeedbackAPI.Domain.validation;
 

namespace EventFeedbackAPI.Domain.Entities
{
    public class Feedback
    {
        public int Id { get; set; }
        public int IdEvent { get; set; }
        public int IdParticipant { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Comment { get; set; }

        public Event Event { get; set; }
        public Participant participant { get; set; }

    

        public  Feedback(int id, int idEvent, int idParticipant, DateTime createdAt, string comment )
        {
            DomainExceptionValidation.When(id < 1, "The event ID cannot be zero or less than zero.");
            this.Id = id;

            validateDomain(idEvent, idParticipant, createdAt, comment);
        }

        public Feedback(int idEvent, int idParticipant, DateTime createdAt, string comment)
        {
            validateDomain(idEvent, idParticipant, createdAt, comment);
        }

        public void Update(int idEvent, int idParticipant, DateTime createdAt, string comment)
        {
            validateDomain( idEvent,  idParticipant,  createdAt,  comment);
        }


        public void validateDomain(int idEvent, int idParticipant, DateTime createdAt, string comment)
        {
            DomainExceptionValidation.When(idEvent < 1, "The idEvent cannot be zero or less than zero.");
            DomainExceptionValidation.When(idParticipant < 1, "The idParticipant cannot be zero or less than zero.");
            DomainExceptionValidation.When(comment.Length > 500, "The comment cannot exceed 500 characters.");
            this.IdEvent = idEvent;
            this.IdParticipant = idParticipant;
            this.CreatedAt = createdAt;
            this.Comment = comment;
           

        }
    }
}
