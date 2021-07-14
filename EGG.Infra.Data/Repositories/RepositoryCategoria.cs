using System;
using EGG.Domain.Entities;
using EGG.Domain.Interfaces.Repositories;
using EGG.Infra.Data.Context;
using EGG.Infra.Data.Repositories.Base;

namespace EGG.Infra.Data.Repositories
{
    public class RepositoryCategoria : RepositoryBase<Categoria, Guid>, IRepositoryCategoria
    {
        public RepositoryCategoria(EGGContext context) : base(context)
        {
        }
    }
}