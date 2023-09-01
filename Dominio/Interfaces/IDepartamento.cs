
using Dominio.Entities;

namespace Dominio.Interfaces;

public interface IDepartamento : IGenericRepo<Departamento>
{
    Task<Departamento> GetByIdAsync(string id);
}