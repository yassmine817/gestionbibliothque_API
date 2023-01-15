using gestionbibliothque_API.DataModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gestionbibliothque_API.Repository
{
    public class SqlLivreRepository : ILivreRepository
    {
        private readonly EmployerAdminContext context;
        public SqlLivreRepository(EmployerAdminContext context)
        {
            this.context = context;
        }


        public async Task< List<Livre>> GetLivres()
        {
            return  await context.Livre.Include(nameof(TypeLivre)).Include(nameof(Auteurs)).ToListAsync();
        }

        public Task<List<Livre>> GetLivresAsync()
        {
            throw new NotImplementedException();
        }
    }
}
