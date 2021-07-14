using System;
using MediatR;

namespace EGG.Domain.Commands.Produto.AlterarProduto
{
    public class AtualizarProdutoRequest : IRequest<Response>
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public Guid CategoriaId { get; set; }
    }
}