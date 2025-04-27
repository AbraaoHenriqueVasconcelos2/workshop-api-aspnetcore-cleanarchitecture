using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventFeedbackAPI.Application.dto;
using EventFeedbackAPI.Domain.Entities;
using EventFeedbackAPI.Domain.pagination;

namespace EventFeedbackAPI.Application.interfaces
{
    public interface IFeedbackService
    {
        Task<FeedbackDtoOut> Create(FeedbackDtoIn feedbackDtoIn);
        Task<FeedbackDtoOut> Update(FeedbackDtoIn FeedbackDtoIn, int id);
        Task<FeedbackDtoOut> Delete(int id);

        Task<FeedbackDtoOut> FindAsync(int id);

        Task<PagedList<FeedbackDtoOut>> FindAllAsync(int pageNumber, int pageSize);
    }
}
