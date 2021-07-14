using EGG.Domain.DTOs;

namespace EGG.Domain.Interfaces.UoW
{
    public interface IUnitOfWork
    {
        CommitResult Commit();
    }
}