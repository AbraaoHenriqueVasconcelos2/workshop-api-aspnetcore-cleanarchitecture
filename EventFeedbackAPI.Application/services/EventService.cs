using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventFeedbackAPI.Application.interfaces;
using EventFeedbackAPI.Application.mapper;
using EventFeedbackAPI.Application.dto;
using EventFeedbackAPI.Domain.interfaces;
using EventFeedbackAPI.Domain.Entities;

using AutoMapper;

namespace EventFeedbackAPI.Application.services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _repository;
        private readonly IMapper _mapper;

        public EventService(IEventRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }

        public async Task<EventDto> Create(EventDto eventDto)
        {
            var ev = _mapper.Map<Event>(eventDto);
            var eventInserted = await _repository.Create(ev);
            return _mapper.Map<EventDto>(eventInserted);
        }

        public async Task<EventDto> Update(EventDto eventDto, int id)
        {
            var ev = _mapper.Map<Event>(eventDto);
            var eventUpdated = await _repository.Update(ev, id);
            return _mapper.Map<EventDto>(eventUpdated);
        }

        public async Task<EventDto> Delete(int id)
        {
            var eventDeleted = await _repository.Delete(id);
            return _mapper.Map<EventDto>(eventDeleted);
        }


        public async Task<EventDto> FindAsync(int id)
        {
            var ev = await  _repository.FindAsync(id);
            return _mapper.Map<EventDto>(ev);
        }

        /*
        public async Task<IEnumerable<ParticipantDto> FindAllAsync()
        {
            var participants = _repository.FindAllAsync();
            return _mapper.Map<IEnumerable<ParticipantDto>>(participant);
        }
        */

    }
}
