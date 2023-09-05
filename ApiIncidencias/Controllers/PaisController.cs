
using ApiIncidencias.Helpers;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using ApiIncidencias.Dtos;
using Microsoft.AspNetCore.Mvc;


namespace ApiIncidencias.Controllers;

    public class PaisController : BaseApiController
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public PaisController (IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;

        }
        /* public async Task<ActionResult<Pager<PaisxDepDto>>> Get11([FromQuery] Params paisParams)
        {
            var pais= await unitOfWork.Paises.GetAllAsync(paisParams.PageIndex,paisParams.PageSize,paisParams.Search);
            var lstPaisesDto=mapper.Map<List<PaisxDepDto>>(pais.registros);
            return new Pager<PaisxDepDto>(lstPaisesDto,pais.totalRegistros,paisParams.PageIndex,paisParams.PageSize,paisParams.Search);
        } */

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<PaisDto>>> Get()
        {
            var pais=await unitOfWork.Paises.GetAllAsync();
            return Ok(pais);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> Get (int id)
        {
            var pais=await unitOfWork.Paises.GetByIdAsync(id);
            return Ok(pais);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pais>> Post(PaisDto paisDto)
        {
            var pais=mapper.Map<Pais>(paisDto);
            this.unitOfWork.Paises.Add(pais);
            await unitOfWork.SaveAsync();
            if (pais==null)
            {
                return BadRequest();
            }
            paisDto.Id=pais.Id;
            return CreatedAtAction(nameof(Post), new {id=paisDto.Id},paisDto);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PaisDto>> Put (int id,[FromBody]PaisDto paisDto){
            if (paisDto==null)
                return NotFound();
            var pais = this.mapper.Map<Pais>(paisDto);
            unitOfWork.Paises.Update(pais);
            await unitOfWork.SaveAsync();
            return paisDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id){
            var pais=await unitOfWork.Paises.GetByIdAsync(id);
            if(pais==null){
                return NotFound();
            }
            unitOfWork.Paises.Remove(pais);
            await unitOfWork.SaveAsync();
            return NoContent();
        }

        /* [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<PaisDto>> Get(string id)
        {
            var pais= await unitOfWork.Pais.GetByIdAsync(id);
            if(pais==null)
            {
                return NotFound(new ApiResponse(404,"El pais solicitado no existe."));
            }
            return mapper.Map<PaisDto>(pais);
        } */

    }
