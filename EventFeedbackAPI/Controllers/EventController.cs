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
    public class EventController : Controller
    {
        private readonly IEventService _service;

        public EventController(IEventService service)
        {
            _service = service;
        }


        [HttpPost]
        public async Task<ActionResult> Create(EventDto eventDto)
        {
            var eventDtoIncluded = await _service.Create(eventDto);
            if (eventDtoIncluded == null)
            {
                return BadRequest("An unexpected error occurred.");
            }

            return Ok(eventDtoIncluded);
        }

        [HttpPut]
        public async Task<ActionResult> Update(EventDto eventDto)
        {
  
            var eventDtoUpdated = await _service.Update(eventDto, eventDto.Id);
            if (eventDtoUpdated == null)
            {
                return BadRequest("An unexpected error occurred.");
            }

            return Ok(eventDtoUpdated);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var eventDtoDeleted = await _service.Delete(id);
            if (eventDtoDeleted == null)
            {
                return BadRequest("An unexpected error occurred.");
            }

            return Ok("Success");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Find(int id)
        {
            var eventDto = await _service.FindAsync(id);
            if (eventDto == null)
            {
                return BadRequest("An unexpected error occurred.");
            }

            return Ok(eventDto);
        }

        /*

        [HttpGet]
        public async Task<ActionResult> FindAll()
        {
            var eventsDto = await _service.FindAllAsync();
             

            return Ok(eventsDto);
        }
        */


    }
}
