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
    }
}
