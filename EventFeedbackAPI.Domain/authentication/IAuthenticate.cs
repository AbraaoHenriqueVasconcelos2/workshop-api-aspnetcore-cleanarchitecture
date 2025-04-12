using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventFeedbackAPI.Domain.authentication
{
    public interface IAuthenticate
    {
        Task<bool> AuthenticateAsync(string cpf, string password);
        Task<bool> participantExists(string cpf);

        public string GenerateToken(int id, string cpf);
        
    }
}
