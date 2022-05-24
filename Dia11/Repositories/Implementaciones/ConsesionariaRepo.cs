using Dia11.Data;
using Dia11.Models;

namespace Dia11.Repositories.Implementaciones
{
    public class ConsesionariaRepo : GenericRepository<Consecionaria>, IConsesionaria
    {
        public ConsesionariaRepo(ApplicationDbContext dbcontext) : base(dbcontext)
        {
        }
    }
}
