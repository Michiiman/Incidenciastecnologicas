using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;

namespace ApiIncidencias.Dtos
{
    public class DepartamentoDto : BaseEntity
    {
        public string NombreDep{ get; set; }
        public int IdPaisFk{ get; set; }

        public List<DepartamentoDto> Departamentos { get; set; }
    }
}