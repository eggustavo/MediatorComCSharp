using EGG.Domain.Entities.Base;

namespace EGG.Domain.Entities
{
    public class Municipio : EntityBase<int>
    {
        public string Nome { get; private set; }

        public Municipio(string nome)
        {
            Nome = nome;
        }
    }
}