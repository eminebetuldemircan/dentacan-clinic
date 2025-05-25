using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {

        Task<IEnumerable<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> filter = null);

        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter);

        Task<TEntity> AddAsync(TEntity entity);

        Task<TEntity> UpdateAsync(TEntity entity);

        Task<bool> DeleteAsync(int id);


        Task<IEnumerable<TEntity>> GetListAsyncPagination(int pageNumber, int pageSize, Expression<Func<TEntity, bool>> filter = null);

        TEntity Get(Expression<Func<TEntity, bool>> filter);

    }
}
