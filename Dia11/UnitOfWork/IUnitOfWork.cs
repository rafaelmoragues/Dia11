using Dia11.Repositories;

namespace Dia11.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IConsesionaria RepoConsesionaria { get; }
        IUnidad RepoUnidad { get; }
        Task SaveChanges();
    }
}
