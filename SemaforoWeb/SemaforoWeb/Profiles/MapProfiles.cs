using AutoMapper;
using Semaforo.Logic.BO;
using Semaforo.Logic.Models;
using SemaforoWeb.DTO.CatalogsDTO.Catalogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SemaforoWeb.Profiles
{
    public class MapProfiles : Profile
    {
        public MapProfiles()
        {
            CreateMap<Client, ClientBO>();
            CreateMap<ClientBO, ClientDTO>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName));

        }
    }
}
