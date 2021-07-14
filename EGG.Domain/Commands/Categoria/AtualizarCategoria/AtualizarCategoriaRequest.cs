using System;
using MediatR;

namespace EGG.Domain.Commands.Categoria.AtualizarCategoria
{
    public class AtualizarCategoriaRequest : IRequest<Response>
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
    }
}