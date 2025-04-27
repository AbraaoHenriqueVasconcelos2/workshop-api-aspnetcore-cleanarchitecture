 using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using EventFeedbackAPI.Application.dto;
using EventFeedbackAPI.Infra.Ioc;
using EventFeedbackAPI.Application.interfaces;
using EventFeedbackAPI.Domain.authentication;
using EventFeedbackAPI.Models;
using EventFeedbackAPI.Extensions;
using Microsoft.AspNetCore.Authorization;

 
namespace EventFeedbackAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FeedbackController : Controller
    {
        private readonly IFeedbackService _service;
        private readonly IAuthenticate _authenticateService;

        public FeedbackController(IFeedbackService service, IAuthenticate authenticateService)
        {
            _service = service;
            _authenticateService = authenticateService;
        }

            
        [HttpPost]
        public async Task<ActionResult> Create(FeedbackDtoIn feedbackDtoIn)
        {
            if(feedbackDtoIn == null)
            {
                return BadRequest("Invalid data!");
            }
 


            var feedbackDtoOut = await _service.Create(feedbackDtoIn);

            if (feedbackDtoOut == null)
            {
                return BadRequest("An unexpected error occurred.");
            }            

            return Ok(feedbackDtoOut);
        }


        /*
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

      
         */
        [HttpGet]
        public async Task<ActionResult> FindAll([FromQuery]PaginationParams _params)
        {
            var feedbacksDtoOut = await _service.FindAllAsync(_params.PageNumber, _params.PageSize);

            Response.AddPaginationHeader(new PaginationHeader(feedbacksDtoOut.CurrentPage, feedbacksDtoOut.PageSize,
                                                              feedbacksDtoOut.TotalCount, feedbacksDtoOut.TotalPages));
            return Ok(feedbacksDtoOut);
        }
        

       
    }
}
