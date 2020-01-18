using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Hackatown2020.Interface;
using Hackatown2020.Models;
using Hackatown2020.Context;
using System.Threading.Tasks;

namespace Hackatown2020.DAL
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseModel
    {
        internal Hackatown2020Context context;
        internal DbSet<TEntity> dbSet;

        public GenericRepository(Hackatown2020Context context)
        {
            this.context = context;
             
            this.dbSet = context.Set<TEntity>();
        }
        public virtual async Task<IEnumerable<TEntity>> GetFilter(Expression<Func<TEntity, bool>> filter,
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null && includeProperties.Any())
            {
                return await includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty)).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }
        }
        public virtual async Task<IEnumerable<TEntity>> Get(
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = dbSet;

            if (includeProperties != null && includeProperties.Any())
            {
                return await includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty)).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }
        }
        public virtual async Task<TEntity> GetByID(int id, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = dbSet;

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return await query.FirstOrDefaultAsync(x=>x.Id == id);
        }

        public virtual async Task Insert(TEntity entity)
        {
            entity.CreatedOn = DateTime.Now;
            entity.ModifiedOn = entity.CreatedOn;
            
            await dbSet.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public virtual async Task Delete(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            await Delete(entityToDelete);
           
        }

        public virtual async Task Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);

            await context.SaveChangesAsync();
        }

        public virtual async Task Update(TEntity entityToUpdate)
        {
            TEntity original = await GetByID(entityToUpdate.Id);
           
            entityToUpdate.CreatedBy = original.CreatedBy;
            entityToUpdate.CreatedOn = original.CreatedOn;
            entityToUpdate.ModifiedOn = DateTime.Now;
            
            context.Entry(original).CurrentValues.SetValues(entityToUpdate);
            context.Entry(original).State = EntityState.Modified;

            await context.SaveChangesAsync();
            
     //       dbSet.Attach(entityToUpdate);


        }
    }
}