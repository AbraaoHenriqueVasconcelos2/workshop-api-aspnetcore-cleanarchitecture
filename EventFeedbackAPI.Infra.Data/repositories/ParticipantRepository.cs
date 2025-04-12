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
    public class ParticipantRepository : IParticipantRepository
    {
        private readonly ApplicationDbContext _context;

        public ParticipantRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<Participant>  Create(Participant participant)
        {
            _context.Participant.Add(participant);
            await _context.SaveChangesAsync();
            return participant;

        }

        public async Task<Participant> Update(Participant participant, int id)
        {
            var participantUpdated = await _context.Participant.FindAsync(id);

            if (participantUpdated == null)
            {
                return null;
            }

            participantUpdated.Cpf = participant.Cpf;
            participantUpdated.Password = participant.Password;
            participantUpdated.Name = participant.Name;
            participantUpdated.Address = participant.Address;
            participantUpdated.City = participant.City;
            participantUpdated.Neighborhood = participant.Neighborhood;

            _context.Participant.Update(participantUpdated);
            await _context.SaveChangesAsync();
            return participant;
        }

        public async Task<Participant> Delete(int id)
        {
            var participant = await _context.Participant.FindAsync(id);
            if (participant != null)
            {
                _context.Participant.Remove(participant);
                await _context.SaveChangesAsync();
                return participant;
            }
            return null;
        }

        public async Task<Participant> FindAsync(int id)
        {
            return await _context.Participant.FirstOrDefaultAsync(x => x.Id == id);
        }




    }
}
