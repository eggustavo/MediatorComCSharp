using MediatR;

namespace EGG.Domain.Commands.Empresa.AdicionarEmpresa
{
    public class AdicionarEmpresaRequest : IRequest<Response>
    {
        public string Nome { get; set; }
    }
}