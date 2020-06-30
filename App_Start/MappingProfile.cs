using AutoMapper;
using Movie_Rentals.DTOs;
using Movie_Rentals.Models;
using Movie_Rentals.ViewModels;
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

            Mapper.CreateMap<ActorViewModel, ActorViewModelDTO>();
            Mapper.CreateMap<ActorViewModelDTO, ActorViewModel>();

            Mapper.CreateMap<Movie, MovieDTO>();
            Mapper.CreateMap<MovieDTO, Movie>();

            Mapper.CreateMap<MembershipType, MembershipTypeDTO>();
            Mapper.CreateMap<MembershipTypeDTO, MembershipType>();
        }
    }
}