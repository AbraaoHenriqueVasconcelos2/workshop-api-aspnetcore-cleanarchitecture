using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventFeedbackAPI.Domain.Entities;

namespace EventFeedbackAPI.Domain.interfaces
{
    public interface IParticipantRepository
    {
        Task<Participant> Create(Participant participant);
        Task<Participant> Update(Participant participant, int id);
        Task<Participant> Delete(int id);

        Task<Participant> FindAsync(int id);
       //Task<IEnumerable<Participant>> findAllAsync();
    }
}
