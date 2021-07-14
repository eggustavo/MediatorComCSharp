using System.Linq.Expressions;
using EGG.Domain.Commands.Pais.AdicionarPais;
using EGG.Domain.Commands.Pais.AtualizarPais;
using EGG.Domain.Commands.Pais.ListarPais;
using EGG.Domain.Commands.Pais.RemoverPais;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using EGG.Domain.DTOs;
using EGG.Domain.Interfaces.Repositories;
using prmToolkit.NotificationPattern;
using EGG.Domain.Resources;
using prmToolkit.NotificationPattern.Extensions;

namespace EGG.Domain.Commands.Pais
{
    public class PaisHandler : Notifiable,
        IRequestHandler<AdicionarPaisRequest, Response>,
        IRequestHandler<AtualizarPaisRequest, Response>,
        IRequestHandler<RemoverPaisRequest, Response>,
        IRequestHandler<ListarPaisRequest, Response>
    {
        private readonly IRepositoryPais _repositoryPais;

        public PaisHandler(IRepositoryPais repositoryPais)
        {
            _repositoryPais = repositoryPais;
        }

        public Task<Response> Handle(AdicionarPaisRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                AddNotification("Request", MSG.OBJETO_X0_E_OBRIGATORIO.ToFormat("Request"));
                return Task.FromResult(new Response(this));
            }

            var pais = new Entities.Pais(request.Nome);
            AddNotifications(pais);

            if (IsInvalid())
                return Task.FromResult(new Response(this));

            _repositoryPais.Adicionar(pais);
            return Task.FromResult(new Response(this,
                new BaseResponse(pais.Id, MSG.X0_REGISTRADO_COM_SUCESSO.ToFormat("País"))));
        }

        public Task<Response> Handle(AtualizarPaisRequest request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<Response> Handle(RemoverPaisRequest request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<Response> Handle(ListarPaisRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new Response(this, _repositoryPais.Listar()));
        }
    }
}