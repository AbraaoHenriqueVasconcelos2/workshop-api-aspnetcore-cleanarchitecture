using System;
using System.Collections.Generic;

using EventFeedbackAPI.Domain.validation;
 

namespace EventFeedbackAPI.Domain.Entities
{
    public class Event
    {
       

        public int Id { get;  set; }
        public string Name { get;   set; }
        public DateTime Date { get;  set; }
        public string Location { get;  set; }
        public string Description { get;  set; }

        public ICollection<Feedback> feedbacks { get; set; }




        public Event(int id, string name, DateTime date, string location, string description)
        {
            DomainExceptionValidation.When(id < 1, "The event ID cannot be zero or less than zero.");
            this.Id = Id;
            validateDomain(name, date, location,description);
            
        }

        public Event(string name, DateTime date, string location, string description)
        {
            validateDomain(name, date, location, description);
        }

        public void Update(string name, DateTime date, string location, string description)
        {
            validateDomain(name, date, location, description);
        }


        public void validateDomain(string name, DateTime date, string location, string description)
        {
            DomainExceptionValidation.When(name.Length > 100, "The event name cannot exceed 100 characters.");
            DomainExceptionValidation.When(location.Length > 100, "The event location  cannot exceed 100 characters.");
            DomainExceptionValidation.When(description.Length > 500, "The event description cannot exceed 500 characters.");
            this.Name = name;
            this.Date = date;
            this.Location = location;
            this.Description = description;
        }



    }
}
