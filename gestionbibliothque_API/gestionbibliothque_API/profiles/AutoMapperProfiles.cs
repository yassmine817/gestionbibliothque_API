using AutoMapper;
using gestionbibliothque_API.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gestionbibliothque_API.profiles
{
    public class AutoMapperProfiles : Profile
    {
       public AutoMapperProfiles()
        {
            CreateMap<DataModels.Livre, Livre>().ReverseMap();
            CreateMap<DataModels.TypeLivre, TypeLivre>().ReverseMap();
            CreateMap<DataModels.Auteurs, Auteurs>().ReverseMap();
        }
    }
}
