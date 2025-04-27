using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EventFeedbackAPI.Application.dto;
using EventFeedbackAPI.Domain.Entities;


namespace EventFeedbackAPI.Application.mapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Participant, ParticipantDto>().ReverseMap();
            CreateMap<Event, EventDto>().ReverseMap();
            CreateMap<Feedback, FeedbackDtoOut>().ReverseMap()
                .ForMember(x => x.Event, y => y.MapFrom(z => z.EventDto))
                .ForMember(x => x.Participant, y => y.MapFrom(z => z.ParticipantDto));

            CreateMap<Feedback, FeedbackDtoIn>().ReverseMap();
           
        }
    }
}
