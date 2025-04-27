using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventFeedbackAPI.Domain.authentication;
using EventFeedbackAPI.Infra.Data.context;
using EventFeedbackAPI.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;


namespace EventFeedbackAPI.Infra.Data.identity
{
    public class AuthenticateService : IAuthenticate
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthenticateService(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<Participant> AuthenticateAsync(string cpf, string password)
        {
            Participant participant = await _context.Participant.Where(x => x.Cpf.ToLower() == cpf.ToLower()).Where(x => x.Password.Trim() == password.Trim()).FirstOrDefaultAsync();
            if(participant == null)
            {
                return null;
            }

            return participant;
        }

        public async Task<bool> participantExists(string cpf)
        {
            var participant = await _context.Participant.Where(x => x.Cpf.ToLower() == cpf.ToLower()).FirstOrDefaultAsync();
            if (participant == null)
            {
                return false;
            }

            return true;
        }

        public string GenerateToken(int id, string cpf)
        {
            var claims = new[]
            {
                new Claim("id", id.ToString()),
                new Claim("cpf", cpf),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var privateKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["jwt:secretKey"]));

            var credentials = new SigningCredentials(privateKey, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddMinutes(10);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _configuration["jwt:issuer"],
                audience: _configuration["jwt:audience"],
                claims: claims,
                expires: expiration,
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
