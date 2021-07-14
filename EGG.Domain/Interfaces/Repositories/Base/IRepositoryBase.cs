using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using EGG.Domain.Entities.Base;

namespace EGG.Domain.Interfaces.Repositories.Base
{
    public interface IRepositoryBase<TEntidade, TId> 
        where TEntidade : EntityBase<TId>
        where TId : struct
    {
        #region Listar

        IEnumerable<TEntidade> Listar();
        IEnumerable<TEntidade> Listar(Func<TEntidade, object> ordem, bool ascendente);
        IEnumerable<TEntidade> Listar(Func<TEntidade, object> ordem, bool ascendente, params Expression<Func<TEntidade, object>>[] incluirPropriedadesNavegacao);
        IEnumerable<TEntidade> Listar(Func<TEntidade, object> ordem, bool ascendente, params string[] incluirPropriedadesNavegacao);
        IEnumerable<TEntidade> Listar(params Expression<Func<TEntidade, object>>[] incluirPropriedadesNavegacao);
        IEnumerable<TEntidade> Listar(params string[] incluirPropriedadesNavegacao);

        #endregion

        #region Listar Sem Rastreamento
        IEnumerable<TEntidade> ListarSemRastreamento();
        IEnumerable<TEntidade> ListarSemRastreamento(Func<TEntidade, object> ordem, bool ascendente);
        IEnumerable<TEntidade> ListarSemRastreamento(Func<TEntidade, object> ordem, bool ascendente, params Expression<Func<TEntidade, object>>[] incluirPropriedadesNavegacao);
        IEnumerable<TEntidade> ListarSemRastreamento(Func<TEntidade, object> ordem, bool ascendente, params string[] incluirPropriedadesNavegacao);
        IEnumerable<TEntidade> ListarSemRastreamento(params Expression<Func<TEntidade, object>>[] incluirPropriedadesNavegacao);
        IEnumerable<TEntidade> ListarSemRastreamento(params string[] incluirPropriedadesNavegacao);

        #endregion

        #region Listar Por...

        IEnumerable<TEntidade> ListarPor(Func<TEntidade, bool> onde);
        IEnumerable<TEntidade> ListarPor(Func<TEntidade, bool> onde, Func<TEntidade, object> ordem, bool ascendente);
        IEnumerable<TEntidade> ListarPor(Func<TEntidade, bool> onde, Func<TEntidade, object> ordem, bool ascendente, params Expression<Func<TEntidade, object>>[] incluirPropriedadesNavegacao);
        IEnumerable<TEntidade> ListarPor(Func<TEntidade, bool> onde, Func<TEntidade, object> ordem, bool ascendente, params string[] incluirPropriedadesNavegacao);
        IEnumerable<TEntidade> ListarPor(Func<TEntidade, bool> onde, params Expression<Func<TEntidade, object>>[] incluirPropriedadesNavegacao);
        IEnumerable<TEntidade> ListarPor(Func<TEntidade, bool> onde, params string[] incluirPropriedadesNavegacao);

        #endregion

        #region Listar Por Sem Rastreamento...

        IEnumerable<TEntidade> ListarPorSemRastreamento(Func<TEntidade, bool> onde);
        IEnumerable<TEntidade> ListarPorSemRastreamento(Func<TEntidade, bool> onde, Func<TEntidade, object> ordem, bool ascendente);
        IEnumerable<TEntidade> ListarPorSemRastreamento(Func<TEntidade, bool> onde, Func<TEntidade, object> ordem, bool ascendente, params Expression<Func<TEntidade, object>>[] incluirPropriedadesNavegacao);
        IEnumerable<TEntidade> ListarPorSemRastreamento(Func<TEntidade, bool> onde, Func<TEntidade, object> ordem, bool ascendente, params string[] incluirPropriedadesNavegacao);
        IEnumerable<TEntidade> ListarPorSemRastreamento(Func<TEntidade, bool> onde, params Expression<Func<TEntidade, object>>[] incluirPropriedadesNavegacao);
        IEnumerable<TEntidade> ListarPorSemRastreamento(Func<TEntidade, bool> onde, params string[] incluirPropriedadesNavegacao);

        #endregion

        #region Obter Por Id

        TEntidade ObterPorId(TId id);
        TEntidade ObterPorId(TId id, params Expression<Func<TEntidade, object>>[] incluirPropriedadesNavegacao);
        TEntidade ObterPorId(TId id, params string[] incluirPropriedadesNavegacao);

        #endregion

        #region Obter Por Id Sem Rastreamento...

        TEntidade ObterPorIdSemRastreamento(TId id);
        TEntidade ObterPorIdSemRastreamento(TId id, params Expression<Func<TEntidade, object>>[] incluirPropriedadesNavegacao);
        TEntidade ObterPorIdSemRastreamento(TId id, params string[] incluirPropriedadesNavegacao);

        #endregion

        #region Obter Por...

        TEntidade ObterPor(Func<TEntidade, bool> onde);
        TEntidade ObterPor(Func<TEntidade, bool> onde, params Expression<Func<TEntidade, object>>[] incluirPropriedadesNavegacao);
        TEntidade ObterPor(Func<TEntidade, bool> onde, params string[] incluirPropriedadesNavegacao);

        #endregion

        #region Obter Por Sem Rastreamento...

        TEntidade ObterPorSemRastreamento(Func<TEntidade, bool> onde);
        TEntidade ObterPorSemRastreamento(Func<TEntidade, bool> onde, params Expression<Func<TEntidade, object>>[] incluirPropriedadesNavegacao);
        TEntidade ObterPorSemRastreamento(Func<TEntidade, bool> onde, params string[] incluirPropriedadesNavegacao);

        #endregion

        #region Verificação

        bool Existe(Func<TEntidade, bool> onde);

        #endregion

        #region Adicionar

        void Adicionar(TEntidade entidade);

        #endregion

        #region Atualizar

        void Atualizar(TEntidade entidade);

        #endregion

        #region Remover

        void Remover(TEntidade entidade);

        #endregion

        #region Query

        IQueryable<TEntidade> Query { get; }

        #endregion
    }
}