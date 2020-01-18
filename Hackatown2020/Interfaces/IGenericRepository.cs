using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;

using System.Linq.Expressions;
using Hackatown2020.Context;
using Hackatown2020;
using Hackatown2020.Interface;
using System.Threading.Tasks;

namespace Hackatown2020.Interface
{
    public interface IGenericRepository<TEntity> where TEntity : IBaseModel
    {
        Task<IEnumerable<TEntity>> Get(
         params Expression<Func<TEntity, object>>[] includeProperties);
        Task<TEntity> GetByID(int id, params Expression<Func<TEntity, object>>[] includeProperties);
        Task Insert(TEntity entity);
        Task Delete(object id);
        Task Delete(TEntity entityToDelete);
        Task Update(TEntity entityToUpdate);
    }
}