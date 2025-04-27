 using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using EventFeedbackAPI.Domain.Entities;
using EventFeedbackAPI.Infra.Ioc;
using EventFeedbackAPI.Application.interfaces;
using EventFeedbackAPI.Domain.authentication;


namespace EventFeedbackAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IParticipantService _service;
        private readonly IAuthenticate _authenticateService;

        public AuthController(IParticipantService service, IAuthenticate authenticateService)
        {
            _service = service;
            _authenticateService = authenticateService;
        }

            
        [HttpPost]
        public async Task<ActionResult> GenerateToken(String cpf, String password)
        {
            if(cpf == null)
            {
                return BadRequest("Invalid data!");
            }
            if (password == null)
            {
                return BadRequest("Invalid data!");
            }

            Participant participantExists = await _authenticateService.AuthenticateAsync(cpf, password);

            if (participantExists == null)
            {
                return BadRequest("Invalid data!");
            }

             

            var token = _authenticateService.GenerateToken(participantExists.Id, participantExists.Cpf);
           

            return Ok(new {Token = token });
        }

        

    }
}
