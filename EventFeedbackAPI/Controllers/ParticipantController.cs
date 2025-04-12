 using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using EventFeedbackAPI.Application.dto;
using EventFeedbackAPI.Infra.Ioc;
using EventFeedbackAPI.Application.interfaces;
 


namespace EventFeedbackAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParticipantController : Controller
    {
        private readonly IParticipantService _service;

        public ParticipantController(IParticipantService service)
        {
            _service = service;
        }


        [HttpPost]
        public async Task<ActionResult> Create(ParticipantDto participant)
        {
            var participantDtoIncluded = await _service.Create(participant);
            if (participantDtoIncluded == null)
            {
                return BadRequest("An unexpected error occurred.");
            }

            return Ok(participantDtoIncluded);
        }

        [HttpPut]
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
        public async Task<ActionResult> Delete(int id)
        {
            var participantDtoDeleted = await _service.Delete(id);
            if (participantDtoDeleted == null)
            {
                return BadRequest("An unexpected error occurred.");
            }

            return Ok("Success");
        }

        [HttpGet("{id}")]
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
