 using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using EventFeedbackAPI.Application.dto;
using EventFeedbackAPI.Infra.Ioc;
using EventFeedbackAPI.Application.interfaces;
using EventFeedbackAPI.Domain.authentication;
using Microsoft.AspNetCore.Authorization;
 
namespace EventFeedbackAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParticipantController : Controller
    {
        private readonly IParticipantService _service;
        private readonly IAuthenticate _authenticateService;

        public ParticipantController(IParticipantService service, IAuthenticate authenticateService)
        {
            _service = service;
            _authenticateService = authenticateService;
        }

            
        [HttpPost]
        public async Task<ActionResult> Create(ParticipantDto participant)
        {
            if(participant == null)
            {
                return BadRequest("Invalid data!");
            }

            var participantExists = await _authenticateService.participantExists(participant.Cpf);

            if (participantExists)
            {
                return BadRequest("This CPF is already registered.");
            }

            var participantDtoIncluded = await _service.Create(participant);
            if (participantDtoIncluded == null)
            {
                return BadRequest("An unexpected error occurred.");
            }

            var token = _authenticateService.GenerateToken(participantDtoIncluded.Id, participantDtoIncluded.Cpf);
           

            return Ok(participantDtoIncluded);
        }



        [HttpPut]
        [Authorize]
        public async Task<ActionResult> Update(ParticipantDto participant)
        {
  
            var participantDtoUpdated = await _service.Update(participant, participant.Id);
            if (participantDtoUpdated == null)
            {
                return BadRequest("An unexpected error occurred.");
            }

            return Ok(participantDtoUpdated);
        }

        [HttpDelete]
        [Authorize]
        public async Task<ActionResult> Delete(int id)
        {
            var participantId = int.Parse(User.FindFirst("id").Value);
            var participant = await _service.FindAsync(participantId);

            if(!participant.IsAdmin)
            {
                return Unauthorized("You are not allowed to perform this action.");
            }

            var participantDtoDeleted = await _service.Delete(id);
            if (participantDtoDeleted == null)
            {
                return BadRequest("An unexpected error occurred.");
            }

            return Ok("Success");
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult> Find(int id)
        {
            var participantDto = await _service.FindAsync(id);
            if (participantDto == null)
            {
                return BadRequest("An unexpected error occurred.");
            }

            return Ok(participantDto);
        }

        /*

        [HttpGet]
        public async Task<ActionResult> FindAll()
        {
            var participantsDto = await _service.FindAllAsync();
             

            return Ok(participantsDto);
        }
        */


    }
}
