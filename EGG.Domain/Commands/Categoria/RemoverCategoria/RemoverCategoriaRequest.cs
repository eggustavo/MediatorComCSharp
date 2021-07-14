using System;
using MediatR;

namespace EGG.Domain.Commands.Categoria.RemoverCategoria
{
    public class RemoverCategoriaRequest : IRequest<Response>
    {
        public Guid Id { get; }

        public RemoverCategoriaRequest(Guid id)
        {
            Id = id;
        }
    }
}