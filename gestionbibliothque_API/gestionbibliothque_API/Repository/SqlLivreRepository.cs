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



        public async Task<List<Livre>> GetLivresAsync()
        {
            return await context.Livre.Include(nameof(TypeLivre)).Include(nameof(Auteurs)).ToListAsync();
        }

        public async Task<Livre> GetLivreAsync(Guid LivreId)
        {
            return await context.Livre
                .Include(nameof(TypeLivre)).Include(nameof(Auteurs))
                .FirstOrDefaultAsync(x => x.Id == LivreId);
        }
        
        public async Task<List<Auteurs>> GetAuteursAsync()
        {
            return await context.Auteurs.ToListAsync();
        }

        public async Task<bool> Exists(Guid livreId)
        {
            return await context.Livre.AnyAsync(x => x.Id == livreId);
        }

        public async Task<Livre> UpdateLivre(Guid LivreId, Livre request)
        {
            var existingLivre = await GetLivreAsync(LivreId);
            if (existingLivre != null)
            {
                existingLivre.Titre = request.Titre;
                existingLivre.Auteurs = request.Auteurs;
                existingLivre.Langue = request.Langue;
                existingLivre.maisonEdition = request.maisonEdition;
                existingLivre.Nbpage = request.Nbpage;
                existingLivre.TypeLivre = request.TypeLivre;
                existingLivre.AuteursId = request.AuteursId;
                await context.SaveChangesAsync();
                return existingLivre;
            }

            return null;
        }


        public async Task<Livre> DeleteLivre(Guid LivreId)
        {
            var livre = await GetLivreAsync(LivreId);

            if (livre != null)
            {
                context.Livre.Remove(livre);
                await context.SaveChangesAsync();
                return livre;
            }

            return null;
        }

        public async Task<Livre> AddLivre(Livre request)
        {
            var livre = await context.Livre.AddAsync(request);
            await context.SaveChangesAsync();
            return livre.Entity;
        }


        public async Task<Auteurs> AddAuteur(Auteurs request)
        {
            var auteur = await context.Auteurs.AddAsync(request);
            await context.SaveChangesAsync();
            return auteur.Entity;
        }

        public async Task<Auteurs> GetOneAuteurAsync(Guid AuteurId)
        {
            return await context.Auteurs

                .FirstOrDefaultAsync(x => x.Id == AuteurId);

        }

    
    }
}