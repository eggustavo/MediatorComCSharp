using System;
using MediatR;

namespace EGG.Domain.Commands.Empresa.AtualizarEmpresa
{
    public class AtualizarEmpresaRequest : IRequest<Response>
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
    }
}