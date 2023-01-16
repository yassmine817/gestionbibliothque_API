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

      

        public async Task< List<Livre>> GetLivresAsync()
        {
            return  await context.Livre.Include(nameof(TypeLivre)).Include(nameof(Auteurs)).ToListAsync();
        }

        public async Task <Livre> GetLivreAsync(Guid LivreId)
        {
            return await context.Livre
                .Include(nameof(TypeLivre)).Include(nameof(Auteurs))
                .FirstOrDefaultAsync(x => x.Id == LivreId);
        }

   
    }
}
