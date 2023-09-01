
using Dominio.Entities;

namespace Dominio.Interfaces;

public interface ICiudad : IGenericRepo<Ciudad>
{
    Task<Ciudad> GetByIdAsync(string id);
}