namespace EGG.Domain.DTOs
{
    public class BaseResponse
    {
        public object Id { get; }
        public string Mensagem { get; }

        public BaseResponse(object id, string mensagem)
        {
            Id = id;
            Mensagem = mensagem;
        }
    }
}