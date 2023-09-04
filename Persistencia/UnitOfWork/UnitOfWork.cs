using Dominio.Interfaces;
using Persistencia;
using Persistencia.Repository;

namespace Persistencia.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApiIncidenciasContext context;
        private PaisRepository _paises;

        public UnitOfWork(ApiIncidenciasContext _context)
        {
            context = _context;
        }

        public IPais Paises
        {
            get
            {
                if (_paises == null)
                {
                    _paises = new PaisRepository(context);
                }
                return _paises;
            }
        }

        public int Save()
        {
            return context.SaveChanges();
        }
        public void Dispose()
        {
            context.Dispose();
        }
        public async Task<int> SaveAsync()
        {
            return await context.SaveChangesAsync();
        }
    }
}