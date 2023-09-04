
using Dominio.Interfaces;

namespace ApiIncidencias.Controllers;

    public class PaisController : BaseApiController
    {
        private readonly IUnitOfWork unitOfWork;

        public PaisController (IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
    }
