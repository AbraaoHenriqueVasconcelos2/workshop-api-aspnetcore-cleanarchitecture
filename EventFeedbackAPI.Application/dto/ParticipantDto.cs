using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;


namespace EventFeedbackAPI.Application.dto
{
    public class ParticipantDto
    {
        [IgnoreDataMember]
        public int Id { get;  set; }

        [Required(ErrorMessage = "cpf is required!")]
        [StringLength(20, MinimumLength = 11, ErrorMessage = "The maximum number of characters is 20")]
        public string Cpf { get;  set; }

        [Required(ErrorMessage = "password is required!")]
        [StringLength(20,   ErrorMessage = "The maximum number of characters is 20")]
        public string Password { get; set; }


        [Required(ErrorMessage = "Name is required!")]
        [StringLength(100, ErrorMessage = "The maximum number of characters is 100")]
        public string Name { get;  set; }

        [StringLength(100, ErrorMessage = "The maximum number of characters is 100")]
        public string Address { get;  set; }

        [StringLength(100, ErrorMessage = "The maximum number of characters is 100")]
        public string City { get;  set; }

        [StringLength(100, ErrorMessage = "The maximum number of characters is 100")]
        public string Neighborhood { get;  set; }
         
    }
}
