
using AutoMapper;
using gestionbibliothque_API.DomainModels;
using System;

namespace gestionbibliothque_API.profiles.AfterMapper
{
    public class AddLivreRequestAfterMap : IMappingAction<AddLivreRequest, DataModels.Livre>
    {
        public void Process(AddLivreRequest source, DataModels.Livre destination, ResolutionContext context)
        {

            destination.Id = Guid.NewGuid();
        }
    }
}