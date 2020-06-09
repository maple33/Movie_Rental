using AutoMapper;
using Movie_Rentals.DTOs;
using Movie_Rentals.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace Movie_Rentals.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDTO>();
            Mapper.CreateMap<CustomerDTO, Customer>();
            Mapper.CreateMap<Actor, ActorDTO>();
            Mapper.CreateMap<ActorDTO, Actor>();
        }
    }
}