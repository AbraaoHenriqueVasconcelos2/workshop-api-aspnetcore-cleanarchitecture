using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventFeedbackAPI.Application.interfaces;
using EventFeedbackAPI.Application.mapper;
using EventFeedbackAPI.Application.dto;
using EventFeedbackAPI.Domain.interfaces;
using EventFeedbackAPI.Domain.Entities;
using EventFeedbackAPI.Domain.pagination;

using AutoMapper;

namespace EventFeedbackAPI.Application.services
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IFeedbackRepository _repository;
        private readonly IEventRepository _eventRepository;
        private readonly IParticipantRepository _participantRepository;

        private readonly IMapper _mapper;

        public FeedbackService(IFeedbackRepository repository, IEventRepository eventRepository, IParticipantRepository participantRepository , IMapper mapper)
        {
            _repository = repository;
            _eventRepository = eventRepository;
            _participantRepository = participantRepository;
            _mapper = mapper;

        }

        public async Task<FeedbackDtoOut> Create(FeedbackDtoIn feedbackDtoIn)
        {
          

            var eventInserted = await _eventRepository.FindAsync(feedbackDtoIn.IdEvent);

            var participantInserted = await _participantRepository.FindAsync(feedbackDtoIn.IdParticipant);

            if (eventInserted == null || participantInserted == null)
            {
                return null;
            }

            var feedback = _mapper.Map<Feedback>(feedbackDtoIn);

            var feedbackInserted = await _repository.Create(feedback);


            var feedbackDtoOut = _mapper.Map<FeedbackDtoOut>(feedbackInserted);

            feedbackDtoOut.EventDto = _mapper.Map<EventDto>(eventInserted);
            
            feedbackDtoOut.ParticipantDto = _mapper.Map<ParticipantDto>(participantInserted);
             

            return feedbackDtoOut;
        }

       
        public async Task<FeedbackDtoOut> Update(FeedbackDtoIn feedbackDtoIn, int id)
        {
            var feedback = _mapper.Map<Feedback>(feedbackDtoIn);
            var feedbackUpdated = await _repository.Update(feedback, id);

            return _mapper.Map<FeedbackDtoOut>(feedbackUpdated);
        }
       
       public async Task<FeedbackDtoOut> Delete(int id)
       {
           var feedbackDeleted = await _repository.Delete(id);
           return _mapper.Map<FeedbackDtoOut>(feedbackDeleted);
       }


       public async Task<FeedbackDtoOut> FindAsync(int id)
       {
           var feedback = await  _repository.FindAsync(id);
           return _mapper.Map<FeedbackDtoOut>(feedback);
       }

       
       public async Task<PagedList<FeedbackDtoOut>> FindAllAsync(int pageNumber, int pageSize)
       {
           var feedbacks = await  _repository.FindAllAsync( pageNumber,  pageSize);
           var feedbacksDtoOut = _mapper.Map<IEnumerable<FeedbackDtoOut>>(feedbacks);
            return new PagedList<FeedbackDtoOut>(feedbacksDtoOut, pageNumber, feedbacks.TotalPages,pageSize, feedbacks.TotalCount);
       }
  

    }
}
