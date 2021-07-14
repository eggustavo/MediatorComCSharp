using MediatR;

namespace EGG.Domain.Commands.Pais.AdicionarPais
{
    public class AdicionarPaisRequest : IRequest<Response>
    {
        public string Nome { get; set; }
    }
}