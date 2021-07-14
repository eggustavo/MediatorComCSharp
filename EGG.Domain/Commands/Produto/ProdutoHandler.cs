using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using EGG.Domain.Commands.Produto.AdicionarProduto;
using EGG.Domain.Commands.Produto.AlterarProduto;
using EGG.Domain.Commands.Produto.ListarProduto;
using EGG.Domain.Commands.Produto.RemoverProduto;
using EGG.Domain.DTOs;
using EGG.Domain.Interfaces.Repositories;
using EGG.Domain.Resources;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;

namespace EGG.Domain.Commands.Produto
{
    public class ProdutoHandler : Notifiable,
        IRequestHandler<AdicionarProdutoRequest, Response>,
        IRequestHandler<AtualizarProdutoRequest, Response>,
        IRequestHandler<RemoverProdutoRequest, Response>,
        IRequestHandler<ListarProdutoRequest, Response>
    {
        private readonly IRepositoryProduto _repositoryProduto;
        private readonly IRepositoryCategoria _repositoryCategoria;

        public ProdutoHandler(IRepositoryProduto repositoryProduto, IRepositoryCategoria repositoryCategoria)
        {
            _repositoryProduto = repositoryProduto;
            _repositoryCategoria = repositoryCategoria;
        }

        public Task<Response> Handle(ListarProdutoRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                AddNotification("Request", MSG.OBJETO_X0_E_OBRIGATORIO.ToFormat("Request"));
                return Task.FromResult(new Response(this));
            }

            return Task.FromResult(new Response(this, _repositoryProduto.Listar(incluirPropriedadesNavegacao: p => p.Categoria).Select(p => new
            //return Task.FromResult(new Response(this, _repositoryProduto.ListarPorSemRastreamento(p => true, "Categoriaccccc").Select(p => new
            {
                Id = p.Id,
                Descricao = p.Descricao,
                Categoria = p.Categoria.Descricao,
                Valor = p.Valor
            }))); ;
        }

        public Task<Response> Handle(AdicionarProdutoRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                AddNotification("Request", MSG.OBJETO_X0_E_OBRIGATORIO.ToFormat("Request"));
                return Task.FromResult(new Response(this));
            }

            var categoria = _repositoryCategoria.ObterPorId(request.CategoriaId);
            //if (categoria == null)
            //    AddNotification("Categoria", MSG.X0_NAO_LOCALIZADA.ToFormat("Categoria"));

            var produto = new Entities.Produto(request.Descricao, request.Valor, categoria);
            AddNotifications(produto);

            if (IsInvalid())
                return Task.FromResult(new Response(this));

            _repositoryProduto.Adicionar(produto);

            return Task.FromResult(new Response(this,
                new BaseResponse(produto.Id, MSG.X0_REGISTRADO_COM_SUCESSO.ToFormat("Produto"))));
        }

        public Task<Response> Handle(AtualizarProdutoRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                AddNotification("Request", MSG.OBJETO_X0_E_OBRIGATORIO.ToFormat("Request"));
                return Task.FromResult(new Response(this));
            }

            var produto = _repositoryProduto.ObterPorId(request.Id);
            if (produto == null)
            {
                AddNotification("Produto", MSG.X0_NAO_LOCALIZADO.ToFormat("Produto"));
                return Task.FromResult(new Response(this));
            }

            var categoria = _repositoryCategoria.ObterPorId(request.CategoriaId);
            if (categoria == null)
                AddNotification("Categoria", MSG.X0_NAO_LOCALIZADA.ToFormat("Categoria"));


            produto.Atualizar(request.Descricao, request.Valor, categoria);
            AddNotifications(produto);

            if (IsInvalid())
                return Task.FromResult(new Response(this));

            _repositoryProduto.Atualizar(produto);

            return Task.FromResult(new Response(this,
                new BaseResponse(produto.Id, MSG.X0_ATUALIZADO_COM_SUCESSO.ToFormat("Produto"))));
        }

        public Task<Response> Handle(RemoverProdutoRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                AddNotification("Request", MSG.OBJETO_X0_E_OBRIGATORIO.ToFormat("Request"));
                return Task.FromResult(new Response(this));
            }

            var produto = _repositoryProduto.ObterPorId(request.Id);
            if (produto == null)
            {
                AddNotification("Produto", MSG.X0_NAO_LOCALIZADO.ToFormat("Produto"));
                return Task.FromResult(new Response(this));
            }

            _repositoryProduto.Remover(produto);

            return Task.FromResult(new Response(this,
                new BaseResponse(produto.Id, MSG.X0_REMOVIDO_COM_SUCESSO.ToFormat("Produto"))));
        }
    }
}