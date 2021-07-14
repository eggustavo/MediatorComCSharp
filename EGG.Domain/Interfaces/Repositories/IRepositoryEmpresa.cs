using System;
using EGG.Domain.Entities;
using EGG.Domain.Interfaces.Repositories.Base;

namespace EGG.Domain.Interfaces.Repositories
{
    public interface IRepositoryEmpresa : IRepositoryBase<Empresa, Guid>
    {
        
    }
}