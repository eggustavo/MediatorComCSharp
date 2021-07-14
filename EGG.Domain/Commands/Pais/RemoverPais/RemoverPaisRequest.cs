using MediatR;

namespace EGG.Domain.Commands.Pais.RemoverPais
{
    public class RemoverPaisRequest : IRequest<Response>
    {
        public int Id { get; }

        public RemoverPaisRequest(int id)
        {
            Id = id;
        }
    }
}