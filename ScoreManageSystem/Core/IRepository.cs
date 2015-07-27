using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ScoreManageSystem.Domain;

namespace ScoreManageSystem.Core
{
    public interface IRepository<T> where T : BaseEntity
    {
        #region Select/Get/Query

        IQueryable<T> GetAll();

        List<T> GetAllList();


        List<T> GetAllList(Expression<Func<T, bool>> predicate);


        T Query<T>(Func<IQueryable<T>, T> queryMethod);


        T Get(int id);


        T Single(Expression<Func<T, bool>> predicate);

        T FirstOrDefault(int id);


        T FirstOrDefault(Expression<Func<T, bool>> predicate);
        T Load(int id);

        #endregion

        #region Insert

        T Insert(T entity);

        int InsertAndGetId(T entity);

        T InsertOrUpdate(T entity);

        int InsertOrUpdateAndGetId(T entity);


        #endregion

        #region Update

        /// <summary>
        /// Updates an existing entity.
        /// </summary>
        /// <param name="entity">Entity</param>
        T Update(T entity);

        T Update(int id, Action<T> updateAction);


        #endregion

        #region Delete

        void Delete(T entity);
        void Delete(int id);

        void Delete(Expression<Func<T, bool>> predicate);

        #endregion

        #region Aggregates

        int Count();

        int Count(Expression<Func<T, bool>> predicate);

        long LongCount();

        long LongCount(Expression<Func<T, bool>> predicate);

        #endregion
    }
}
