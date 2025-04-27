using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace EventFeedbackAPI.Application.dto
{
    public class FeedbackDtoIn
    {
 


        public int IdEvent { get; set; }
        public int IdParticipant { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Comment { get; set; }
 

    }
}
