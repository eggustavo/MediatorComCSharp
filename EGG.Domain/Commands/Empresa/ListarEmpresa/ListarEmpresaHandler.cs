using MediatR;
using System.Threading;
using System.Threading.Tasks;
using EGG.Domain.Interfaces.Repositories;
using prmToolkit.NotificationPattern;
using EGG.Domain.Resources;
using prmToolkit.NotificationPattern.Extensions;

namespace EGG.Domain.Commands.Empresa.ListarEmpresa
{
    public class ListarEmpresaHandler : Notifiable, IRequestHandler<ListarEmpresaRequest, Response>
    {
        private readonly IRepositoryEmpresa _repositoryEmpresa;

        public ListarEmpresaHandler(IRepositoryEmpresa repositoryEmpresa)
        {
            _repositoryEmpresa = repositoryEmpresa;
        }

        public async Task<Response> Handle(ListarEmpresaRequest request, CancellationToken cancellationToken)
        {
            //Valida se o objeto request esta nulo
            if (request == null)
            {
                AddNotification("Request", MSG.OBJETO_X0_E_OBRIGATORIO.ToFormat("Request"));
                return new Response(this);
            }

            ////Retorna o resultado
            return await Task.FromResult(new Response(this, _repositoryEmpresa.ListarSemRastreamento(p => p.Nome, false)));
        }
    }
}