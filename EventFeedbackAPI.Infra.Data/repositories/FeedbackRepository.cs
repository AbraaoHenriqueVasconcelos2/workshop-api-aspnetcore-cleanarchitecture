using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventFeedbackAPI.Domain.interfaces;
using EventFeedbackAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using EventFeedbackAPI.Infra.Data.context;
using EventFeedbackAPI.Domain.pagination;
using EventFeedbackAPI.Infra.Data.helpers;
 
namespace EventFeedbackAPI.Infra.Data.repositories
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly ApplicationDbContext _context;

        public FeedbackRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Feedback> Create(Feedback feedback)
        {
            _context.Feedback.Add(feedback);
            await _context.SaveChangesAsync();
            return feedback;
        }

        public async Task<Feedback> Update(Feedback feedback, int id)
        {
            var feedbackUpdated = await _context.Feedback.FindAsync(id);

            if (feedbackUpdated == null)
            {
                return null;
            }

            feedbackUpdated.IdEvent = feedback.IdEvent;
            feedbackUpdated.IdParticipant = feedback.IdParticipant;
            feedbackUpdated.CreatedAt = feedback.CreatedAt;
            feedbackUpdated.Comment = feedback.Comment; 

            _context.Feedback.Update(feedbackUpdated);
            await _context.SaveChangesAsync();
            return feedback; 
        }

        public async Task<Feedback> Delete(int id)
        {
            var feedback = await _context.Feedback.FindAsync(id);
            if(feedback != null)
            {
                _context.Feedback.Remove(feedback);
                await _context.SaveChangesAsync();
                return feedback;
            }

            return null;
        }

        public async Task<Feedback> FindAsync(int id)
        {
            return await _context.Feedback.FirstOrDefaultAsync(x => x.Id == id);
                
        }

        /*
        public async Task<IEnumerable<Feedback>> FindAllAsync()
        {
            return await _context.Feedback.ToListAsync();
        }
        */
        public async Task<PagedList<Feedback>> FindAllAsync(int pageNumber, int pageSize)
        {
            //var query =  _context.Feedback.OrderBy(x => x.Id).AsQueryable();
            var query = _context.Feedback.OrderByDescending(x => x.Id).AsQueryable();
            return await PaginationHelper.CreateAsync(query, pageNumber, pageSize);
        }
    }
}
