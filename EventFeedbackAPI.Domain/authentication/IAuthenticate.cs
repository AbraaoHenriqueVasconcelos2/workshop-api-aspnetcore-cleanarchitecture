using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventFeedbackAPI.Domain.Entities
    ;

namespace EventFeedbackAPI.Domain.authentication
{
    public interface IAuthenticate
    {
        Task<Participant> AuthenticateAsync(string cpf, string password);
        Task<bool> participantExists(string cpf);

        public string GenerateToken(int id, string cpf);
        
    }
}
