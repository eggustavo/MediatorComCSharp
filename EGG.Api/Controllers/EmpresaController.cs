using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using EGG.Api.Controllers.Base;
using EGG.Domain.Commands.Empresa.AdicionarEmpresa;
using EGG.Domain.Commands.Empresa.AtualizarEmpresa;
using EGG.Domain.Commands.Empresa.ListarEmpresa;
using EGG.Domain.Commands.Empresa.RemoverEmpresa;
using EGG.Domain.Interfaces.UoW;

namespace EGG.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : BaseController
    {
        private readonly IMediator _mediator;

        public EmpresaController(IUnitOfWork uow, IMediator mediator) : base(uow)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("listar")]
        public async Task<IActionResult> ListarEmpresa()
        {
            return CreateActionResult(await _mediator.Send(new ListarEmpresaRequest()));
        }

        [HttpPost]
        [Route("adicionar")]
        public async Task<IActionResult> AdicionarEmpresa(AdicionarEmpresaRequest request)
        {
            return CreateActionResult(await _mediator.Send(request, CancellationToken.None));
        }

        [HttpPut]
        [Route("atualizar")]
        public async Task<IActionResult> AtualizarEmpresa(AtualizarEmpresaRequest request)
        {
            return CreateActionResult(await _mediator.Send(request, CancellationToken.None));
        }

        [HttpDelete]
        [Route("remover/{id}")]
        public async Task<IActionResult> RemoverEmpresar(Guid id)
        {
            var request = new RemoverEmpresaRequest(id);
            return CreateActionResult(await _mediator.Send(request, CancellationToken.None));
        }
    }
}
