using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EventFeedbackAPI.Application.dto
{
    public class PaginationParams
    {
        [Range(1, int.MaxValue)]
        public int PageNumber { get; set; }

        [Range(1,5, ErrorMessage = "The maximum number of items per page is 5.")]
        public int PageSize { get; set; }
    }
}
