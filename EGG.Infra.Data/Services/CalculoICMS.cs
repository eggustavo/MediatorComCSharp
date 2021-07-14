using EGG.Domain.Interfaces.Services;

namespace EGG.Infra.Data.Services
{
    public class CalculoICMS : IServiceCalculoICMS
    {
        public decimal CalcularICMS(decimal valor)
        {
            return valor * 0.18m;
        }
    }
}