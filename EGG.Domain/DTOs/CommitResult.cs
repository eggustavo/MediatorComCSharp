namespace EGG.Domain.DTOs
{
    public class CommitResult
    {
        public bool Sucesso { get; }
        public string MensagemErro { get; }
        public string MensagemErroDetalhada { get; }

        public CommitResult(bool sucesso, string mensagemErro, string mensagemErroDetalhada)
        {
            Sucesso = sucesso;
            MensagemErro = mensagemErro;
            MensagemErroDetalhada = mensagemErroDetalhada;
        }
    }
}