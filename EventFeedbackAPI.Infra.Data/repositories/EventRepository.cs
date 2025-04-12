using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EventFeedbackAPI.Domain.interfaces;
using EventFeedbackAPI.Domain.Entities;
using EventFeedbackAPI.Infra.Data.context;

namespace EventFeedbackAPI.Infra.Data.repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly ApplicationDbContext _context;

        public EventRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<Event>  Create(Event ev)
        {
            _context.Event.Add(ev);
            await _context.SaveChangesAsync();
            return ev;

        }

        public async Task<Event> Update(Event ev, int id)
        {
            var eventUpdated = await _context.Event.FindAsync(id);

            if (eventUpdated == null)
            {
                return null;
            }

            eventUpdated.Name = ev.Name;
            eventUpdated.Date = ev.Date;
            eventUpdated.Location = ev.Location;
            eventUpdated.Description = ev.Description;

            _context.Event.Update(eventUpdated);
            await _context.SaveChangesAsync();
            return eventUpdated;
        }

        public async Task<Event> Delete(int id)
        {
            var eventDeleted = await _context.Event.FindAsync(id);
            if (eventDeleted != null)
            {
                _context.Event.Remove(eventDeleted);
                await _context.SaveChangesAsync();
                return eventDeleted;
            }
            return null;
        }

        public async Task<Event> FindAsync(int id)
        {
            return await _context.Event.FirstOrDefaultAsync(x => x.Id == id);
        }




    }
}
