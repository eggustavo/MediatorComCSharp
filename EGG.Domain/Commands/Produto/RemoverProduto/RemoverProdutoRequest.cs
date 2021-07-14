using System;
using MediatR;

namespace EGG.Domain.Commands.Produto.RemoverProduto
{
    public class RemoverProdutoRequest : IRequest<Response>
    {
        public Guid Id { get; }

        public RemoverProdutoRequest(Guid id)
        {
            Id = id;
        }
    }
}