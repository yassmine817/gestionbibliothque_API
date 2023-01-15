using Microsoft.EntityFrameworkCore;
namespace gestionbibliothque_API.DataModels
{
    public class EmployerAdminContext : DbContext
    {
        EmployerAdminContext(DbContextOptions<EmployerAdminContext> options) : base(options)
        {

        }
        public DbSet<Livre> Livre {get;set;}
        public DbSet<TypeLivre> TypeLivre { get; set; }
        public DbSet<Auteurs> Auteurs { get; set; }
    }
}
