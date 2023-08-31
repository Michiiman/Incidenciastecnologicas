using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities;

    public class Ciudad:BaseEntity
    {
        public string NombreCiudad{ get; set; }
        public string IdDepFk{ get; set; }
        public Departamento Departamento{ get; set; }


    }
