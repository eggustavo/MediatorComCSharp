using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using EGG.Api.Controllers.Base;
using EGG.Domain.Commands.Categoria.AdicionarCategoria;
using EGG.Domain.Commands.Categoria.AtualizarCategoria;
using EGG.Domain.Commands.Categoria.ListarCategoria;
using EGG.Domain.Commands.Categoria.RemoverCategoria;
using EGG.Domain.Interfaces.UoW;

namespace EGG.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : BaseController
    {
        private readonly IMediator _mediator;

        public CategoriaController(IUnitOfWork uow, IMediator mediator) : base(uow)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("listar")]
        public async Task<IActionResult> ListarCategoria()
        {
            return CreateActionResult(await _mediator.Send(new ListarCategoriaRequest()));
        }

        [HttpPost]
        [Route("adicionar")]
        public async Task<IActionResult> AdicionarCategoria(AdicionarCategoriaRequest request)
        {
            return CreateActionResult(await _mediator.Send(request, CancellationToken.None));
        }

        [HttpPut]
        [Route("atualizar")]
        public async Task<IActionResult> AtualizarCategoria(AtualizarCategoriaRequest request)
        {
            return CreateActionResult(await _mediator.Send(request, CancellationToken.None));
        }

        [HttpDelete]
        [Route("remover/{id}")]
        public async Task<IActionResult> RemoverCategoria(Guid id)
        {
            var request = new RemoverCategoriaRequest(id);
            return CreateActionResult(await _mediator.Send(request, CancellationToken.None));
        }
    }
}
