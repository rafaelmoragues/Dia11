using Dia11.Data;
using Dia11.Models;

namespace Dia11.Repositories.Implementaciones
{
    public class UnidadRepo : GenericRepository<Unidad>, IUnidad
    {
        public UnidadRepo(ApplicationDbContext dbcontext) : base(dbcontext)
        {
        }
    }
}
