using ApiIncidencias.Dtos;
using Dominio;
using AutoMapper;
using Dominio.Entities;


namespace ApiIncidencias.Profiles;

    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Pais,PaisDto>().ReverseMap();
/*             CreateMap<Departamento,DepartamentoDto>().ReverseMap();
 */
        }
    }
