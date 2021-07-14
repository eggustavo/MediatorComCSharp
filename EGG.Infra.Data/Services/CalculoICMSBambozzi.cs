using EGG.Domain.Interfaces.Services;

namespace EGG.Infra.Data.Services
{
    public class CalculoICMSBambozzi : IServiceCalculoICMS
    {
        public decimal CalcularICMS(decimal valor)
        {
            return valor * 0.12m;
        }
    }
}