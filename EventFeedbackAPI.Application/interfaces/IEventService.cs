using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventFeedbackAPI.Application.dto;
using EventFeedbackAPI.Domain.Entities;

namespace EventFeedbackAPI.Application.interfaces
{
    public interface IEventService
    {
        Task<EventDto> Create(EventDto participantDto);
        Task<EventDto> Update(EventDto participantDto, int id);
        Task<EventDto> Delete(int id);

        Task<EventDto> FindAsync(int id);
    }
}
