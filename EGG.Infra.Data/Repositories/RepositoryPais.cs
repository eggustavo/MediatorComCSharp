using EGG.Domain.Entities;
using EGG.Domain.Interfaces.Repositories;
using EGG.Infra.Data.Context;
using EGG.Infra.Data.Repositories.Base;

namespace EGG.Infra.Data.Repositories
{
    public class RepositoryPais : RepositoryBase<Pais, int>, IRepositoryPais
    {
        public RepositoryPais(EGGContext context) : base(context)
        {
        }
    }
}