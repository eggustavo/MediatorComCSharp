using EGG.Domain.Entities.Base;

namespace EGG.Domain.Entities
{
    public class Pais : EntityBase<int>
    {
        public string Nome { get; private set; }

        public Pais(string nome)
        {
            Nome = nome;
        }
    }
}