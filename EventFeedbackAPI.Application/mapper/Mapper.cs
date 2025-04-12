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
           
        }
    }
}
