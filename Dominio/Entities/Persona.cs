using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities;

    public class Persona:BaseEntity
    {
        public string NombrePersona { get; set; }
        public string ApellidoPersona { get; set;}
        public string Direccion { get; set; }
        public int IdGeneroFk { get; set; }
        public Genero Genero { get; set; }
        public int IdCiudadFK { get; set; }
        public Ciudad Ciudad { get; set; }
        public int IdTipoPerFk { get; set; }
        public TipoPersona TipoPersona { get; set; }
        public ICollection<Matricula> Matriculas { get; set; }
        public ICollection<TrainerSalon> TrainerSalones { get; set; }
        public ICollection<Salon> Salones =new HashSet<Salon>();
    }
