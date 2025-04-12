using System;
using System.Collections.Generic;

using EventFeedbackAPI.Domain.validation;
 

namespace EventFeedbackAPI.Domain.Entities
{
    public   class Participant
    {
      

        public int Id { get;  set; }
        public string Cpf { get;  set; }
        public string Password { get; set; }
        public string Name { get;  set; }
        public string Address { get;  set; }
        public string City { get;  set; }
        public string Neighborhood { get;  set; }

        public ICollection<Feedback> feedbacks { get; private set; }


        public Participant(int id, string cpf, string password,  string name, string address, string city, string neighborhood)
        {
            DomainExceptionValidation.When(id < 1, "The event ID cannot be zero or less than zero.");
            this.Id = Id;
            validateDomain(cpf, password, name, address, city, neighborhood);

        }


        public Participant(string cpf, string password, string name, string address, string city, string neighborhood)
        {
            validateDomain(cpf, password, name, address, city, neighborhood);
        }

        public void Update(int id, string cpf, string password, string name, string address, string city, string neighborhood)
        {
         
            validateDomain(cpf, password, name, address, city, neighborhood);
        }


        public void validateDomain(string cpf, string password, string name, string address, string city, string neighborhood)
        {
            DomainExceptionValidation.When(cpf.Length > 20, "The Participant cpf cannot exceed 20 characters.");
            DomainExceptionValidation.When(password.Length > 20, "The Participant password cannot exceed 20 characters.");
            DomainExceptionValidation.When(name.Length > 100, "The Participant name cannot exceed 100 characters.");
            DomainExceptionValidation.When(address.Length > 100, "The Participant address cannot exceed 100 characters.");
            DomainExceptionValidation.When(city.Length > 100, "The Participant city cannot exceed 100 characters.");
            DomainExceptionValidation.When(neighborhood.Length > 100, "The Participant neighborhood cannot exceed 100 characters.");

            
            this.Cpf = cpf;
            this.Password = password;
            this.Name = name;
            this.Address = address;
            this.City = city;
            this.Neighborhood = neighborhood;
       
        }


    }
}
