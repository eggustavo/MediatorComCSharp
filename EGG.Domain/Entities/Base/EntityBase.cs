using prmToolkit.NotificationPattern;

namespace EGG.Domain.Entities.Base
{
    public class EntityBase<TId> : Notifiable where TId : struct
    {
        public TId Id { get; protected set; }
    }
}