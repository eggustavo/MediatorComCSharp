using System;
using MediatR;

namespace EGG.Domain.Commands.Categoria.AdicionarCategoria
{
    public class AdicionarCategoriaRequest : IRequest<Response>
    {
        public string Descricao { get; set; }
    }
}