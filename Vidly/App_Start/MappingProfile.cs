using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.DTO;
using Vidly.Models;

namespace Vidly.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDTO>()
            .ForMember(m => m.id, opt => opt.Ignore());
            Mapper.CreateMap<CustomerDTO, Customer>()
            .ForMember(m => m.id, opt => opt.Ignore());

            Mapper.CreateMap<MembershipTypeDto, MembershipType>();
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();


            Mapper.CreateMap<Genre, GenreDto>();
            Mapper.CreateMap<GenreDto, Genre>();

            Mapper.CreateMap<Movie, MovieDto>()
                .ForMember(m=>m.ID , opt=>opt.Ignore());
            Mapper.CreateMap<MovieDto, Movie>()
                .ForMember(m => m.ID, opt => opt.Ignore());



        }
    }
}