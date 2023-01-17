using AutoMapper;
using gestionbibliothque_API.DomainModels;
using gestionbibliothque_API.profiles.AfterMapper;
namespace gestionbibliothque_API.profiles
{
    public class AutoMapperProfiles : Profile
    {

        public AutoMapperProfiles()
        {
            CreateMap<DataModels.Livre, Livre>()
                .ReverseMap();

            CreateMap<DataModels.Auteurs, Auteurs>()
                .ReverseMap();

            CreateMap<DataModels.TypeLivre, TypeLivre>()
                .ReverseMap();

        
            CreateMap<AddLivreRequest, DataModels.Livre>()
                .AfterMap<AddLivreRequestAfterMap>();

            CreateMap<AddAuteurRequest, DataModels.Auteurs>();
            CreateMap<UpdateLivreRequest, DataModels.Livre>();

        }
    }
         
        } 