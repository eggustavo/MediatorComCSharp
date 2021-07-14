using System;
using EGG.Domain.Entities.Base;
using prmToolkit.NotificationPattern;

namespace EGG.Domain.Entities
{
    public class Empresa : EntityBase<Guid>
    {
        public string Nome { get; private set; }

        //Construtor EF
        protected Empresa() { }

        public Empresa(string nome)
        {
            Id = Guid.NewGuid();
            Nome = nome;

            new AddNotifications<Empresa>(this)
                .IfNullOrInvalidLength(p => p.Nome, 1, 200);
        }

        public void Atualizar(string nome)
        {
            Nome = nome;

            new AddNotifications<Empresa>(this)
                .IfNullOrInvalidLength(p => p.Nome, 1, 200);
        }
    }
}