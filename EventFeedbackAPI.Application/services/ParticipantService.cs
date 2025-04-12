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
    public class ParticipantService : IParticipantService
    {
        private readonly IParticipantRepository _repository;
        private readonly IMapper _mapper;

        public ParticipantService(IParticipantRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }

        public async Task<ParticipantDto> Create(ParticipantDto participantDto)
        {
            var participant = _mapper.Map<Participant>(participantDto);
            var participantInserted = await _repository.Create(participant);
            return _mapper.Map<ParticipantDto>(participantInserted);
        }

        public async Task<ParticipantDto> Update(ParticipantDto participantDto, int id)
        {
            var participant = _mapper.Map<Participant>(participantDto);
            var participantUpdated = await _repository.Update(participant, id);
            return _mapper.Map<ParticipantDto>(participantUpdated);
        }

        public async Task<ParticipantDto> Delete(int id)
        {
            var participantDeleted = await _repository.Delete(id);
            return _mapper.Map<ParticipantDto>(participantDeleted);
        }


        public async Task<ParticipantDto> FindAsync(int id)
        {
            var participant = await  _repository.FindAsync(id);
            return _mapper.Map<ParticipantDto>(participant);
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
