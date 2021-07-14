using prmToolkit.NotificationPattern;

namespace EGG.Domain.Entities.Notifications
{
    public static class CategoriaNotifications
    {
        public static void AdicionarCategoriaNotifications(this Categoria categoria)
        {
            new AddNotifications<Categoria>(categoria)
                .IfNullOrInvalidLength(p => p.Descricao, 2, 200);
        }

        public static void AtualizarCategoriaNotifications(this Categoria categoria)
        {
            new AddNotifications<Categoria>(categoria)
                .IfNullOrInvalidLength(p => p.Descricao, 3, 200);
        }
    }
}