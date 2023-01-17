using gestionbibliothque_API.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gestionbibliothque_API.Repository
{
    public interface ILivreRepository
    {
        Task<List<Livre>> GetLivresAsync();
        Task<Livre> GetLivreAsync(Guid LivreId);
        Task<Auteurs> GetOneAuteurAsync(Guid AuteurId);

        Task<List<Auteurs>> GetAuteursAsync();
        Task<Auteurs> AddAuteur(Auteurs request);

        Task<bool> Exists(Guid LivreId);
        Task<Livre> UpdateLivre(Guid LivreId, Livre request);
        Task<Livre> DeleteLivre(Guid LivreId);
        Task<Livre> AddLivre(Livre request);
    }
}
