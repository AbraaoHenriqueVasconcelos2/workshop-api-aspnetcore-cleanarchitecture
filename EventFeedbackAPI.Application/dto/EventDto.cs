using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;


namespace EventFeedbackAPI.Application.dto
{
    public class EventDto
    {
        [IgnoreDataMember]
        public int Id { get;  set; }

        [Required(ErrorMessage = "Name is required!")]
        [StringLength(100, ErrorMessage = "The maximum number of characters is 100")]
        public string Name { get;  set; }

        [Required]
        public DateTime Date { get;  set; }


        [StringLength(100, ErrorMessage = "The maximum number of characters is 100")]
        public string Location { get;  set; }


        [StringLength(500, ErrorMessage = "The maximum number of characters is 500")]
        public string Description { get;  set; }
         
    }
}
