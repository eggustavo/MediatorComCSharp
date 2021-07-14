using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using EGG.Api.Controllers.Base;
using EGG.Domain.Commands.Pais.AdicionarPais;
using EGG.Domain.Commands.Pais.ListarPais;
using EGG.Domain.Interfaces.UoW;

namespace EGG.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaisController : BaseController
    {
        public readonly IMediator _mediator;

        public PaisController(IUnitOfWork uow, IMediator mediator) : base(uow)
        {
            _mediator = mediator;
        }

        [HttpGet("listar")]
        public async Task<IActionResult> ListarPais()
        {
            return CreateActionResult(await _mediator.Send(new ListarPaisRequest()));
        }


        [HttpPost("adicionar")]
        public async Task<IActionResult> AdicionarPais(AdicionarPaisRequest request)
        {
            return CreateActionResult(await _mediator.Send(request, CancellationToken.None));
        }
    }
}
