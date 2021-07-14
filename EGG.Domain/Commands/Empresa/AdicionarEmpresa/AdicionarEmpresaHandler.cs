using System.Threading;
using System.Threading.Tasks;
using MediatR;
using EGG.Domain.DTOs;
using EGG.Domain.Interfaces.Repositories;
using EGG.Domain.Resources;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;

namespace EGG.Domain.Commands.Empresa.AdicionarEmpresa
{
    public class AdicionarEmpresaHandler : Notifiable, IRequestHandler<AdicionarEmpresaRequest, Response>
    {
        private readonly IRepositoryEmpresa _repositoryEmpresa;

        public AdicionarEmpresaHandler(IRepositoryEmpresa repositoryEmpresa) 
        {
            _repositoryEmpresa = repositoryEmpresa;
        }

        public async Task<Response> Handle(AdicionarEmpresaRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                AddNotification("Request", MSG.OBJETO_X0_E_OBRIGATORIO.ToFormat("Request"));
                return new Response(this);
            }

            var empresa = new Entities.Empresa(request.Nome);
            AddNotifications(empresa);

            if (IsInvalid())
                return new Response(this);

            _repositoryEmpresa.Adicionar(empresa);

            return await Task.FromResult(new Response(this, new BaseResponse(empresa.Id, MSG.X0_REGISTRADA_COM_SUCESSO.ToFormat("Empresa"))));
        }
    }
}