using System;
using System.Collections.Generic;
using EGG.Domain.Entities.Base;
using EGG.Domain.Entities.Notifications;

namespace EGG.Domain.Entities
{
    public class Categoria : EntityBase<Guid>
    {
        public string Descricao { get; private set; }
        public virtual IEnumerable<Produto> Produtos { get; private set; }

        //Construtor EF
        protected Categoria() { }

        public Categoria(string descricao)
        {
            Id = Guid.NewGuid();
            Descricao = descricao;

            this.AdicionarCategoriaNotifications();
        }

        public void Atualizar(string descricao)
        {
            Descricao = descricao;

            this.AtualizarCategoriaNotifications();
        }
    }
}