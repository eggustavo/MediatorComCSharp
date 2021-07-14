using System.Threading;
using System.Threading.Tasks;
using MediatR;
using EGG.Domain.DTOs;
using EGG.Domain.Interfaces.Repositories;
using EGG.Domain.Resources;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;

namespace EGG.Domain.Commands.Empresa.AtualizarEmpresa
{
    public class AtualizarEmpresaHandler : Notifiable, IRequestHandler<AtualizarEmpresaRequest, Response>
    {
        private readonly IRepositoryEmpresa _repositoryEmpresa;

        public AtualizarEmpresaHandler(IRepositoryEmpresa repositoryEmpresa)
        {
            _repositoryEmpresa = repositoryEmpresa;
        }

        public async Task<Response> Handle(AtualizarEmpresaRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                AddNotification("Request", MSG.OBJETO_X0_E_OBRIGATORIO.ToFormat("Request"));
                return new Response(this);
            }

            var empresa = _repositoryEmpresa.ObterPorId(request.Id);
            if (empresa == null)
            {
                AddNotification("Empresa", MSG.X0_NAO_LOCALIZADA.ToFormat("Empresa"));
                return new Response(this);
            }

            empresa.Atualizar(request.Nome);
            AddNotifications(empresa);

            if (IsInvalid())
                return new Response(this);

            _repositoryEmpresa.Atualizar(empresa);

            return await Task.FromResult(new Response(this, new BaseResponse(empresa.Id, MSG.X0_ATUALIZADA_COM_SUCESSO.ToFormat("Empresa"))));
        }
    }
}