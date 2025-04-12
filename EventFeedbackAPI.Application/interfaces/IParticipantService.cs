using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventFeedbackAPI.Application.dto;
using EventFeedbackAPI.Domain.Entities;

namespace EventFeedbackAPI.Application.interfaces
{
    public interface IParticipantService
    {
        Task<ParticipantDto> Create(ParticipantDto participantDto);
        Task<ParticipantDto> Update(ParticipantDto participantDto, int id);
        Task<ParticipantDto> Delete(int id);

        Task<ParticipantDto> FindAsync(int id);
    }
}
