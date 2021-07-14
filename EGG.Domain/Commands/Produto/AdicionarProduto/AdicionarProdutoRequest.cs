using System;
using MediatR;

namespace EGG.Domain.Commands.Produto.AdicionarProduto
{
    public class AdicionarProdutoRequest : IRequest<Response>
    {
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public Guid CategoriaId { get; set; }
    }
}