using System;
using EGG.Domain.Entities.Base;
using prmToolkit.NotificationPattern;

namespace EGG.Domain.Entities
{
    public class Produto : EntityBase<Guid>
    {
        public string Descricao { get; private set; }
        public decimal Valor { get; private set; }
        public virtual Categoria Categoria { get; private set; }

        //construto EF
        protected Produto() { }

        public Produto(string descricao, decimal valor, Categoria categoria)
        {
            Id = Guid.NewGuid();
            Descricao = descricao;
            Valor = valor;
            Categoria = categoria;

            new AddNotifications<Produto>(this)
                .IfNullOrInvalidLength(p => p.Descricao, 1, 200)
                .IfGreaterThan(p => p.Valor, 0)
                .IfNull(p => p.Categoria);
        }

        public void Atualizar(string descricao, decimal valor, Categoria categoria)
        {
            Descricao = descricao;
            Valor = valor;

            new AddNotifications<Produto>(this)
                .IfNullOrInvalidLength(p => p.Descricao, 1, 200)
                .IfGreaterThan(p => p.Valor, 0)
                .IfNull(p => p.Categoria);
        }
    }
}