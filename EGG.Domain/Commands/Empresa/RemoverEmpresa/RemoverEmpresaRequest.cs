using System;
using MediatR;

namespace EGG.Domain.Commands.Empresa.RemoverEmpresa
{
    public class RemoverEmpresaRequest : IRequest<Response>
    {
        public Guid Id { get; }

        public RemoverEmpresaRequest(Guid id)
        {
            Id = id;
        }
    }
}