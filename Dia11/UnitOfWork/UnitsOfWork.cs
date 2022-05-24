using Dia11.Data;
using Dia11.Repositories;
using Dia11.Repositories.Implementaciones;

namespace Dia11.UnitOfWork
{
    public class UnitsOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        public IConsesionaria RepoConsesionaria { get; private set; }
        public IUnidad RepoUnidad { get; private set; }
        public UnitsOfWork(ApplicationDbContext context)
        {
            _dbContext = context;
            RepoConsesionaria = new ConsesionariaRepo(context);
            RepoUnidad = new UnidadRepo(context);
        }
  

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public async Task SaveChanges()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
