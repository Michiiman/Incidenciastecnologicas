using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Persistencia.Repository;

    public class PaisRepository : GenericRepository<Pais>, IPais
    {
        protected readonly ApiIncidenciasContext _context;
        
        public PaisRepository(ApiIncidenciasContext context) : base (context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Pais>> GetAllAsync()
        {
            return await _context.Paises
                .Include(p => p.Departamentos)
                .ToListAsync();
        }

        public override async Task<Pais> GetByIdAsync(int id)
        {
            return await _context.Paises
                .Include(p => p.Departamentos)
                .FirstOrDefaultAsync(p =>  p.Id == id);
        }
    }

