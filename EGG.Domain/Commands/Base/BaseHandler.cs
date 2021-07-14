using EGG.Domain.Interfaces.UoW;
using prmToolkit.NotificationPattern;

namespace EGG.Domain.Commands.Base
{
    public class BaseHandler : Notifiable
    {
        private readonly IUnitOfWork _uow;

        public BaseHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public bool Commit()
        {
            var commitResult = _uow.Commit();

            if (commitResult.Sucesso)
                return true;

            AddNotification("Persistência",
                commitResult.MensagemErroDetalhada != null
                    ? $"Ocorreu o seguinte erro ao persistir os dados: {commitResult.MensagemErro} - {commitResult.MensagemErroDetalhada}"
                    : $"Ocorreu o seguinte erro ao persistir os dados: {commitResult.MensagemErro}");
            return false;
        }
    }
}