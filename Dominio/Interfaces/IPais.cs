
using Dominio.Entities;

namespace Dominio.Interfaces;

public interface IPais : IGenericRepo<Pais>
{
    Task<Pais> GetByIdAsync(string id);
}