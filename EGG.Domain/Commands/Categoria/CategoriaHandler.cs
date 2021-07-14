using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using EGG.Domain.Commands.Categoria.AdicionarCategoria;
using EGG.Domain.Commands.Categoria.AtualizarCategoria;
using EGG.Domain.Commands.Categoria.ListarCategoria;
using EGG.Domain.Commands.Categoria.RemoverCategoria;
using EGG.Domain.DTOs;
using EGG.Domain.Interfaces.Repositories;
using EGG.Domain.Resources;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;

namespace EGG.Domain.Commands.Categoria
{
    public class CategoriaHandler : Notifiable,
        IRequestHandler<AdicionarCategoriaRequest, Response>,
        IRequestHandler<AtualizarCategoriaRequest, Response>,
        IRequestHandler<ListarCategoriaRequest, Response>
    {
        private readonly IRepositoryCategoria _repositoryCategoria;

        public CategoriaHandler(IRepositoryCategoria repositoryCategoria)
        {
            _repositoryCategoria = repositoryCategoria;
        }

        public Task<Response> Handle(ListarCategoriaRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                AddNotification("Request", MSG.OBJETO_X0_E_OBRIGATORIO.ToFormat("Request"));
                return Task.FromResult(new Response(this));
            }

            return Task.FromResult(new Response(this,
                _repositoryCategoria.ListarSemRastreamento(p => p.Descricao, false)));
        }

        public Task<Response> Handle(AdicionarCategoriaRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                AddNotification("Request", MSG.OBJETO_X0_E_OBRIGATORIO.ToFormat("Request"));
                return Task.FromResult(new Response(this));
            }

            var categoria = new Entities.Categoria(request.Descricao);
            AddNotifications(categoria);

            if (IsInvalid())
                return Task.FromResult(new Response(this));

            _repositoryCategoria.Adicionar(categoria);

            return Task.FromResult(new Response(this,
                new BaseResponse(categoria.Id, MSG.X0_REGISTRADA_COM_SUCESSO.ToFormat("Categoria"))));
        }

        public Task<Response> Handle(AtualizarCategoriaRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                AddNotification("Request", MSG.OBJETO_X0_E_OBRIGATORIO.ToFormat("Request"));
                return Task.FromResult(new Response(this));
            }

            var categoria = _repositoryCategoria.ObterPorId(request.Id);
            if (categoria == null)
            {
                AddNotification("Categoria", MSG.X0_NAO_LOCALIZADA.ToFormat("Categoria"));
                return Task.FromResult(new Response(this));
            }

            categoria.Atualizar(request.Descricao);
            AddNotifications(categoria);

            if (IsInvalid())
                return Task.FromResult(new Response(this));

            _repositoryCategoria.Atualizar(categoria);

            return Task.FromResult(new Response(this,
                new BaseResponse(categoria.Id, MSG.X0_ATUALIZADA_COM_SUCESSO.ToFormat("Categoria"))));
        }

        public Task<Response> Handle(RemoverCategoriaRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                AddNotification("Request", MSG.OBJETO_X0_E_OBRIGATORIO.ToFormat("Request"));
                return Task.FromResult(new Response(this));
            }

            var categoria = _repositoryCategoria.ObterPorId(request.Id);
            if (categoria == null)
            {
                AddNotification("Categoria", MSG.X0_NAO_LOCALIZADA.ToFormat("Categoria"));
                return Task.FromResult(new Response(this));
            }

            _repositoryCategoria.Remover(categoria);

            return Task.FromResult(new Response(this, new BaseResponse(categoria.Id, MSG.X0_REMOVIDA_COM_SUCESSO.ToFormat("Categoria"))));
        }
    }
}