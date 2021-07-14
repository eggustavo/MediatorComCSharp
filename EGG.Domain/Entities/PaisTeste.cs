namespace EGG.Domain.Entities
{
    public class PaisTeste : Pais
    {
        public string PaisTesteDescricao { get; private set; }

        public PaisTeste(string nome, string paisTesteDescricao) : base(nome)
        {
            PaisTesteDescricao = paisTesteDescricao;
        }
    }
}