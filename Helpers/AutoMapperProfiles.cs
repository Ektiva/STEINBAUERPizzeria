using AutoMapper;
using STEINBAUERPizzeria.DTOs;
using STEINBAUERPizzeria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STEINBAUERPizzeria.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Pizza, PizzaDto>();
        }
    }
}
