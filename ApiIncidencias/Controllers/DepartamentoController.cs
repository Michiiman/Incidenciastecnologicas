using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using ApiIncidencias.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ApiIncidencias.Controllers
{
    public class DepartamentoController : BaseApiController
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public DepartamentoController (IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;

        }
    }
}