
using ApiIncidencias.Controllers;

namespace ApiIncidencias.Dtos
{
    public class PaisxDepDto : BaseApiController
    {
        public string NombrePais{ get; set;}
        public List<DepartamentoDto> Departamentos { get; set; }

    }
}