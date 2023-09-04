


namespace Dominio.Interfaces;

    public interface IUnitOfWork
    {
        IPais Paises{ get; }
        Task<int> SaveAsync();
}
