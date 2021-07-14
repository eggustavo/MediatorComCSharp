using EGG.Domain.Entities.Base;
using EGG.Domain.Interfaces.Repositories.Base;
using EGG.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace EGG.Infra.Data.Repositories.Base
{
    public class RepositoryBase<TEntidade, TId> : IRepositoryBase<TEntidade, TId> 
        where TEntidade : EntityBase<TId>
        where TId : struct
    {
        protected readonly DbSet<TEntidade> DbSet;
        protected readonly EGGContext Context;

        public RepositoryBase(EGGContext context)
        {
            DbSet = context.Set<TEntidade>();
            Context = context;
        }

        #region Listar

        public IEnumerable<TEntidade> Listar()
        {
            return DbSet.AsEnumerable();
        }

        public IEnumerable<TEntidade> Listar(Func<TEntidade, object> ordem, bool ascendente)
        {
            return ascendente
                ? DbSet.OrderBy(ordem).AsEnumerable()
                : DbSet.OrderByDescending(ordem).AsEnumerable();
        }

        public IEnumerable<TEntidade> Listar(Func<TEntidade, object> ordem, bool ascendente, params Expression<Func<TEntidade, object>>[] incluirPropriedadesNavegacao)
        {
            if (incluirPropriedadesNavegacao.Any())
                return ascendente
                    ? Include(DbSet, incluirPropriedadesNavegacao).OrderBy(ordem).AsEnumerable()
                    : Include(DbSet, incluirPropriedadesNavegacao).OrderByDescending(ordem).AsEnumerable();

            return ascendente
                ? DbSet.OrderBy(ordem).AsEnumerable()
                : DbSet.OrderByDescending(ordem).AsEnumerable();
        }

        public IEnumerable<TEntidade> Listar(Func<TEntidade, object> ordem, bool ascendente, params string[] incluirPropriedadesNavegacao)
        {
            if (incluirPropriedadesNavegacao.Any())
                return ascendente
                    ? Include(DbSet, incluirPropriedadesNavegacao).OrderBy(ordem).AsEnumerable()
                    : Include(DbSet, incluirPropriedadesNavegacao).OrderByDescending(ordem).AsEnumerable();

            return ascendente
                ? DbSet.OrderBy(ordem).AsEnumerable()
                : DbSet.OrderByDescending(ordem).AsEnumerable();
        }

        public IEnumerable<TEntidade> Listar(params Expression<Func<TEntidade, object>>[] incluirPropriedadesNavegacao)
        {
            if (incluirPropriedadesNavegacao.Any())
                return Include(DbSet, incluirPropriedadesNavegacao).AsEnumerable();

            return DbSet.AsEnumerable();
        }

        public IEnumerable<TEntidade> Listar(params string[] incluirPropriedadesNavegacao)
        {
            if (incluirPropriedadesNavegacao.Any())
                return Include(DbSet, incluirPropriedadesNavegacao).AsEnumerable();

            return DbSet.AsEnumerable();
        }

        #endregion

        #region Listar Sem Rastreamento

        public IEnumerable<TEntidade> ListarSemRastreamento()
        {
            return DbSet.AsNoTracking().AsEnumerable();
        }

        public IEnumerable<TEntidade> ListarSemRastreamento(Func<TEntidade, object> ordem, bool ascendente)
        {
            return ascendente
                ? DbSet.AsNoTracking().OrderBy(ordem).AsEnumerable()
                : DbSet.AsNoTracking().OrderByDescending(ordem).AsEnumerable();
        }

        public IEnumerable<TEntidade> ListarSemRastreamento(Func<TEntidade, object> ordem, bool ascendente, params Expression<Func<TEntidade, object>>[] incluirPropriedadesNavegacao)
        {
            if (incluirPropriedadesNavegacao.Any())
                return ascendente
                    ? Include(DbSet, incluirPropriedadesNavegacao).AsNoTracking().OrderBy(ordem).AsEnumerable()
                    : Include(DbSet, incluirPropriedadesNavegacao).AsNoTracking().OrderByDescending(ordem).AsEnumerable();

            return ascendente
                ? DbSet.AsNoTracking().OrderBy(ordem).AsEnumerable()
                : DbSet.AsNoTracking().OrderByDescending(ordem).AsEnumerable();
        }

        public IEnumerable<TEntidade> ListarSemRastreamento(Func<TEntidade, object> ordem, bool ascendente, params string[] incluirPropriedadesNavegacao)
        {
            if (incluirPropriedadesNavegacao.Any())
                return ascendente
                    ? Include(DbSet, incluirPropriedadesNavegacao).AsNoTracking().OrderBy(ordem).AsEnumerable()
                    : Include(DbSet, incluirPropriedadesNavegacao).AsNoTracking().OrderByDescending(ordem).AsEnumerable();

            return ascendente
                ? DbSet.AsNoTracking().OrderBy(ordem).AsEnumerable()
                : DbSet.AsNoTracking().OrderByDescending(ordem).AsEnumerable();
        }

        public IEnumerable<TEntidade> ListarSemRastreamento(params Expression<Func<TEntidade, object>>[] incluirPropriedadesNavegacao)
        {
            if (incluirPropriedadesNavegacao.Any())
                return Include(DbSet, incluirPropriedadesNavegacao).AsNoTracking().AsEnumerable();

            return DbSet.AsNoTracking().AsEnumerable();
        }

        public IEnumerable<TEntidade> ListarSemRastreamento(params string[] incluirPropriedadesNavegacao)
        {
            if (incluirPropriedadesNavegacao.Any())
                return Include(DbSet, incluirPropriedadesNavegacao).AsNoTracking().AsEnumerable();

            return DbSet.AsNoTracking().AsEnumerable();
        }

        #endregion

        #region Listar Por...

        public IEnumerable<TEntidade> ListarPor(Func<TEntidade, bool> onde)
        {
            return DbSet.Where(onde).AsEnumerable();
        }

        public IEnumerable<TEntidade> ListarPor(Func<TEntidade, bool> onde, Func<TEntidade, object> ordem, bool ascendente)
        {
            return ascendente
                ? DbSet.Where(onde).OrderBy(ordem).AsEnumerable()
                : DbSet.Where(onde).OrderByDescending(ordem).AsEnumerable();
        }

        public IEnumerable<TEntidade> ListarPor(Func<TEntidade, bool> onde, Func<TEntidade, object> ordem, bool ascendente, params Expression<Func<TEntidade, object>>[] incluirPropriedadesNavegacao)
        {
            if (incluirPropriedadesNavegacao.Any())
                return ascendente
                    ? Include(DbSet, incluirPropriedadesNavegacao).Where(onde).OrderBy(ordem).AsEnumerable()
                    : Include(DbSet, incluirPropriedadesNavegacao).Where(onde).OrderByDescending(ordem).AsEnumerable();

            return ascendente
                ? DbSet.Where(onde).OrderBy(ordem).AsEnumerable()
                : DbSet.Where(onde).OrderByDescending(ordem).AsEnumerable();
        }

        public IEnumerable<TEntidade> ListarPor(Func<TEntidade, bool> onde, Func<TEntidade, object> ordem, bool ascendente, params string[] incluirPropriedadesNavegacao)
        {
            if (incluirPropriedadesNavegacao.Any())
                return ascendente
                    ? Include(DbSet, incluirPropriedadesNavegacao).Where(onde).OrderBy(ordem).AsEnumerable()
                    : Include(DbSet, incluirPropriedadesNavegacao).Where(onde).OrderByDescending(ordem).AsEnumerable();

            return ascendente
                ? DbSet.Where(onde).OrderBy(ordem).AsEnumerable()
                : DbSet.Where(onde).OrderByDescending(ordem).AsEnumerable();
        }

        public IEnumerable<TEntidade> ListarPor(Func<TEntidade, bool> onde, params Expression<Func<TEntidade, object>>[] incluirPropriedadesNavegacao)
        {
            if (incluirPropriedadesNavegacao.Any())
                return Include(DbSet, incluirPropriedadesNavegacao).Where(onde).AsEnumerable();

            return DbSet.Where(onde).AsEnumerable();
        }

        public IEnumerable<TEntidade> ListarPor(Func<TEntidade, bool> onde, params string[] incluirPropriedadesNavegacao)
        {
            if (incluirPropriedadesNavegacao.Any())
                return Include(DbSet, incluirPropriedadesNavegacao).Where(onde).AsEnumerable();

            return DbSet.Where(onde).AsEnumerable();
        }

        #endregion

        #region Listar Por Sem Rastreamento...

        public IEnumerable<TEntidade> ListarPorSemRastreamento(Func<TEntidade, bool> onde)
        {
            return DbSet.AsNoTracking().Where(onde).AsEnumerable();
        }

        public IEnumerable<TEntidade> ListarPorSemRastreamento(Func<TEntidade, bool> onde, Func<TEntidade, object> ordem, bool ascendente)
        {
            return ascendente
                ? DbSet.AsNoTracking().Where(onde).OrderBy(ordem).AsEnumerable()
                : DbSet.AsNoTracking().Where(onde).OrderByDescending(ordem).AsEnumerable();
        }

        public IEnumerable<TEntidade> ListarPorSemRastreamento(Func<TEntidade, bool> onde, Func<TEntidade, object> ordem, bool ascendente,
            params Expression<Func<TEntidade, object>>[] incluirPropriedadesNavegacao)
        {
            if (incluirPropriedadesNavegacao.Any())
                return ascendente
                    ? Include(DbSet, incluirPropriedadesNavegacao).AsNoTracking().Where(onde).OrderBy(ordem).AsEnumerable()
                    : Include(DbSet, incluirPropriedadesNavegacao).AsNoTracking().Where(onde).OrderByDescending(ordem).AsEnumerable();

            return ascendente
                ? DbSet.AsNoTracking().Where(onde).OrderBy(ordem).AsEnumerable()
                : DbSet.AsNoTracking().Where(onde).OrderByDescending(ordem).AsEnumerable();
        }

        public IEnumerable<TEntidade> ListarPorSemRastreamento(Func<TEntidade, bool> onde, Func<TEntidade, object> ordem, bool ascendente,
            params string[] incluirPropriedadesNavegacao)
        {
            if (incluirPropriedadesNavegacao.Any())
                return ascendente
                    ? Include(DbSet, incluirPropriedadesNavegacao).AsNoTracking().Where(onde).OrderBy(ordem).AsEnumerable()
                    : Include(DbSet, incluirPropriedadesNavegacao).AsNoTracking().Where(onde).OrderByDescending(ordem).AsEnumerable();

            return ascendente
                ? DbSet.AsNoTracking().Where(onde).OrderBy(ordem).AsEnumerable()
                : DbSet.AsNoTracking().Where(onde).OrderByDescending(ordem).AsEnumerable();
        }

        public IEnumerable<TEntidade> ListarPorSemRastreamento(Func<TEntidade, bool> onde, params Expression<Func<TEntidade, object>>[] incluirPropriedadesNavegacao)
        {
            if (incluirPropriedadesNavegacao.Any())
                return Include(DbSet, incluirPropriedadesNavegacao).AsNoTracking().Where(onde).AsEnumerable();

            return DbSet.AsNoTracking().Where(onde).AsEnumerable();
        }

        public IEnumerable<TEntidade> ListarPorSemRastreamento(Func<TEntidade, bool> onde, params string[] incluirPropriedadesNavegacao)
        {
            if (incluirPropriedadesNavegacao.Any())
                return Include(DbSet, incluirPropriedadesNavegacao).AsNoTracking().Where(onde).AsEnumerable();

            return DbSet.AsNoTracking().Where(onde).AsEnumerable();
        }

        #endregion

        #region ObterPorId

        public TEntidade ObterPorId(TId id)
        {
            return DbSet.Find(id);
        }

        public TEntidade ObterPorId(TId id, params Expression<Func<TEntidade, object>>[] incluirPropriedadesNavegacao)
        {
            if (incluirPropriedadesNavegacao.Any())
                return Include(DbSet, incluirPropriedadesNavegacao).FirstOrDefault(p => p.Id.ToString() == id.ToString());

            return DbSet.FirstOrDefault(p => p.Id.ToString() == id.ToString());
        }

        public TEntidade ObterPorId(TId id, params string[] incluirPropriedadesNavegacao)
        {
            if (incluirPropriedadesNavegacao.Any())
                return Include(DbSet, incluirPropriedadesNavegacao).FirstOrDefault(p => p.Id.ToString() == id.ToString());

            return DbSet.FirstOrDefault(p => p.Id.ToString() == id.ToString());
        }

        #endregion

        #region ObterPorIdSemRastreamento

        public TEntidade ObterPorIdSemRastreamento(TId id)
        {
            return DbSet.AsNoTracking().FirstOrDefault(p => p.Id.ToString() == id.ToString());
        }

        public TEntidade ObterPorIdSemRastreamento(TId id, params Expression<Func<TEntidade, object>>[] incluirPropriedadesNavegacao)
        {
            if (incluirPropriedadesNavegacao.Any())
                return Include(DbSet, incluirPropriedadesNavegacao).FirstOrDefault(p => p.Id.ToString() == id.ToString());

            return DbSet.FirstOrDefault(p => p.Id.ToString() == id.ToString());
        }

        public TEntidade ObterPorIdSemRastreamento(TId id, params string[] incluirPropriedadesNavegacao)
        {
            if (incluirPropriedadesNavegacao.Any())
                return Include(DbSet, incluirPropriedadesNavegacao).FirstOrDefault(p => p.Id.ToString() == id.ToString());

            return DbSet.FirstOrDefault(p => p.Id.ToString() == id.ToString());
        }

        #endregion

        #region Obter Por...

        public TEntidade ObterPor(Func<TEntidade, bool> onde)
        {
            return DbSet.AsNoTracking().FirstOrDefault(onde);
        }

        public TEntidade ObterPor(Func<TEntidade, bool> onde, params Expression<Func<TEntidade, object>>[] incluirPropriedadesNavegacao)
        {
            if (incluirPropriedadesNavegacao.Any())
                return Include(DbSet, incluirPropriedadesNavegacao).FirstOrDefault(onde);

            return DbSet.FirstOrDefault(onde);
        }

        public TEntidade ObterPor(Func<TEntidade, bool> onde, params string[] incluirPropriedadesNavegacao)
        {
            if (incluirPropriedadesNavegacao.Any())
                return Include(DbSet, incluirPropriedadesNavegacao).FirstOrDefault(onde);

            return DbSet.FirstOrDefault(onde);
        }

        #endregion

        #region Obter Por Sem Rastreamento...

        public TEntidade ObterPorSemRastreamento(Func<TEntidade, bool> onde)
        {
            return DbSet.AsNoTracking().FirstOrDefault(onde);
        }

        public TEntidade ObterPorSemRastreamento(Func<TEntidade, bool> onde, params Expression<Func<TEntidade, object>>[] incluirPropriedadesNavegacao)
        {
            if (incluirPropriedadesNavegacao.Any())
                return Include(DbSet, incluirPropriedadesNavegacao).FirstOrDefault(onde);

            return DbSet.FirstOrDefault(onde);
        }

        public TEntidade ObterPorSemRastreamento(Func<TEntidade, bool> onde, params string[] incluirPropriedadesNavegacao)
        {
            if (incluirPropriedadesNavegacao.Any())
                return Include(DbSet, incluirPropriedadesNavegacao).FirstOrDefault(onde);

            return DbSet.FirstOrDefault(onde);
        }

        #endregion
        
        #region Verificação

        public bool Existe(Func<TEntidade, bool> onde)
        {
            return DbSet.Any(onde);
        }

        #endregion

        #region Adicionar
        public void Adicionar(TEntidade entidade)
        {
            DbSet.Add(entidade);
        }

        #endregion

        #region Atualizar

        public void Atualizar(TEntidade entidade)
        {
            DbSet.Update(entidade);
        }

        #endregion

        #region Remover

        public void Remover(TEntidade entidade)
        {
            DbSet.Remove(entidade);
        }

        #endregion

        #region Query

        public IQueryable<TEntidade> Query => DbSet.AsQueryable();

        #endregion

        #region Rotinas para inclusão de Propriedades de Navegação

        private IQueryable<TEntidade> Include(IQueryable<TEntidade> query, params Expression<Func<TEntidade, object>>[] incluirPropriedadesNavegacao)
        {
            foreach (var property in incluirPropriedadesNavegacao)
                query = query.Include(property);

            return query;
        }

        private IQueryable<TEntidade> Include(IQueryable<TEntidade> query, params string[] incluirPropriedadesNavegacao)
        {
            foreach (var navProperty in incluirPropriedadesNavegacao)
                query = query.Include(navProperty);

            return query;
        }

        #endregion
    }
}