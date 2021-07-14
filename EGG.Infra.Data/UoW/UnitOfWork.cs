using System;
using EGG.Domain.DTOs;
using EGG.Domain.Interfaces.UoW;
using EGG.Infra.Data.Context;

namespace EGG.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EGGContext _context;

        public UnitOfWork(EGGContext context)
        {
            _context = context;
        }

        public CommitResult Commit()
        {
            try
            {
                _context.SaveChanges();
                return new CommitResult(true, null, null);
            }
            catch (Exception e)
            {
                return new CommitResult(false, e.Message, e.InnerException?.Message);
            }
        }
    }
}