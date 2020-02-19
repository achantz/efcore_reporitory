using System;
using System.Linq;
using System.Linq.Expressions;
using api.DB;
using api.DB.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.DB
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected RepositoryContext RespositoryContext { get; set; }
        public RepositoryBase(RepositoryContext repositoryContext)
        {
            this.RespositoryContext = repositoryContext;
        }

        public void Create(T entity)
        {
            this.RespositoryContext.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            this.RespositoryContext.Set<T>().Remove(entity);
        }

        public IQueryable<T> FindAll()
        {
            return this.RespositoryContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.RespositoryContext.Set<T>().Where(expression).AsNoTracking();
        }

        public void Update(T entity)
        {
            this.RespositoryContext.Set<T>().Update(entity);
        }
    }
}