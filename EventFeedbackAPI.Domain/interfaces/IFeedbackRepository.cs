using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventFeedbackAPI.Domain.Entities;
using EventFeedbackAPI.Domain.pagination;

namespace EventFeedbackAPI.Domain.interfaces
{
    public interface IFeedbackRepository
    {
        Task<Feedback> Create(Feedback feedback);
        Task<Feedback> Update(Feedback feedback, int id);
        Task<Feedback> Delete(int id);
        Task<Feedback> FindAsync(int id);
        Task<PagedList<Feedback>> FindAllAsync(int pageNumber, int pageSize);
    }
}
