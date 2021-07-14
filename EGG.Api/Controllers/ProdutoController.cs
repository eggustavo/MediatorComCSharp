using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using EGG.Api.Controllers.Base;
using EGG.Domain.Commands.Categoria.RemoverCategoria;
using EGG.Domain.Commands.Empresa.AtualizarEmpresa;
using EGG.Domain.Commands.Produto.AdicionarProduto;
using EGG.Domain.Commands.Produto.AlterarProduto;
using EGG.Domain.Commands.Produto.ListarProduto;
using EGG.Domain.Commands.Produto.RemoverProduto;
using EGG.Domain.Interfaces.UoW;

namespace EGG.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : BaseController
    {
        private readonly IMediator _mediator;

        public ProdutoController(IUnitOfWork uow, IMediator mediator) : base(uow)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("listar")]
        public async Task<IActionResult> ListarCategoria()
        {
            return CreateActionResult(await _mediator.Send(new ListarProdutoRequest()));
        }

        [HttpPost]
        [Route("adicionar")]
        public async Task<IActionResult> AdicionarCategoria(AdicionarProdutoRequest request)
        {
            return CreateActionResult(await _mediator.Send(request, CancellationToken.None));
        }

        [HttpPut]
        [Route("atualizar")]
        public async Task<IActionResult> AtualizarEmpresa(AtualizarProdutoRequest request)
        {
            return CreateActionResult(await _mediator.Send(request, CancellationToken.None));
        }

        [HttpDelete]
        [Route("remover/{id}")]
        public async Task<IActionResult> RemoverEmpresar(Guid id)
        {
            var request = new RemoverProdutoRequest(id);
            return CreateActionResult(await _mediator.Send(request, CancellationToken.None));
        }
    }
}
