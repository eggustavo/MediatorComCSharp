using System.Threading;
using System.Threading.Tasks;
using MediatR;
using EGG.Domain.DTOs;
using EGG.Domain.Interfaces.Repositories;
using EGG.Domain.Resources;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;

namespace EGG.Domain.Commands.Empresa.RemoverEmpresa
{
    public class RemoverEmpresaHandler : Notifiable, IRequestHandler<RemoverEmpresaRequest, Response>
    {
        private readonly IRepositoryEmpresa _repositoryEmpresa;

        public RemoverEmpresaHandler(IRepositoryEmpresa repositoryEmpresa)
        {
            _repositoryEmpresa = repositoryEmpresa;
        }

        public async Task<Response> Handle(RemoverEmpresaRequest request, CancellationToken cancellationToken)
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

            _repositoryEmpresa.Remover(empresa);

            return await Task.FromResult(new Response(this, new BaseResponse(empresa.Id, MSG.X0_REMOVIDA_COM_SUCESSO.ToFormat("Empresa"))));
        }
    }
}