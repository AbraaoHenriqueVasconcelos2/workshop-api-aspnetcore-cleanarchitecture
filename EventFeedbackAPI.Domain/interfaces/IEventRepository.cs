using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventFeedbackAPI.Domain.Entities;

namespace EventFeedbackAPI.Domain.interfaces
{
    public interface IEventRepository
    {
        Task<Event> Create(Event ev);
        Task<Event> Update(Event ev, int id);
        Task<Event> Delete(int id);

        Task<Event> FindAsync(int id);
       //Task<IEnumerable<Participant>> findAllAsync();
    }
}
