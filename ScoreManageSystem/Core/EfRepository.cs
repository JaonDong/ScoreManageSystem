using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using ScoreManageSystem.Domain;

namespace ScoreManageSystem.Core
{
    public class EfRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected EfDbContext Context;
        protected DbSet<TEntity> Table { get { return Context.Set<TEntity>(); } }

        public EfRepository(EfDbContext dbContext)
        {
            Context = dbContext;
        }

        public IQueryable<TEntity> GetAll()
        {
            return Table;
        }

        public List<TEntity> GetAllList()
        {
            return GetAll().ToList();
        }

        public List<TEntity> GetAllList(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            return GetAll().Where(predicate).ToList();
        }
        public T Query<T>(Func<IQueryable<TEntity>, T> queryMethod)
        {
            return queryMethod(GetAll());
        }

        public TEntity Get(int id)
        {
            var entity = FirstOrDefault(id);
            if(entity==null)
                throw new Exception(typeof(TEntity).FullName + "为null,id为"+id);

            return entity;
        }
        public TEntity Single(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            return GetAll().Single(predicate);
        }

        public TEntity FirstOrDefault(int id)
        {
            return FirstOrDefault(p => p.Id==id);
        }

        public TEntity FirstOrDefault(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            return GetAll().FirstOrDefault(predicate);
        }

        public TEntity Load(int id)
        {
            return Get(id);
        }

        public TEntity Insert(TEntity entity)
        {
            return Table.Add(entity);
        }

        public int InsertAndGetId(TEntity entity)
        {
            return Insert(entity).Id;
        }

        public TEntity InsertOrUpdate(TEntity entity)
        {
            return EqualityComparer<int>.Default.Equals(entity.Id, default(int))
               ? Insert(entity)
               : Update(entity);
        }

        public int InsertOrUpdateAndGetId(TEntity entity)
        {
            return InsertOrUpdate(entity).Id;
        }

        public TEntity Update(TEntity entity)
        {
            AttachIfNot(entity);
            Context.Entry(entity).State=EntityState.Modified;

            return entity;
        }

        public TEntity Update(int id, Action<TEntity> updateAction)
        {
            var entity = Get(id);
            updateAction(entity);
            return entity;
        }

        public void Delete(TEntity entity)
        {
            AttachIfNot(entity);
            //软删除 基础实现
            //if(entity is IsSoffDelete)
            //{
            //  (entity as IsSoffDelete).IsDelete=true;    
            //}
            Table.Remove(entity);
        }

        public void Delete(int id)
        {
            var entity = Table.FirstOrDefault(e => e.Id == id);
            if(entity==null)
                throw new Exception("id为"+id+"的对象不存在");
            Delete(entity);
        }

        public void Delete(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            foreach (var entity in GetAll().Where(predicate).ToList())
            {
                Delete(entity);
            }
        }

        public int Count()
        {
            return GetAll().Count();
        }

        public int Count(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            return GetAll().Count(predicate);
        }

        public long LongCount()
        {
            return GetAll().LongCount();
        }

        public long LongCount(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            return GetAll().LongCount(predicate);
        }

        protected virtual void AttachIfNot(TEntity entity)
        {
            if (!Table.Local.Contains(entity))
            {
                Table.Attach(entity);
            }
        }

       
    }
}