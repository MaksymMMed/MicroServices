using DAL.Exceptions;
using DAL.Repositories.Interfces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace DAL.Repositories.Realization
{
    public abstract class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly UnitContext databaseContext;

        protected readonly DbSet<TEntity> table;

        protected readonly IDistributedCache DistributedCache;
        public virtual async Task<IEnumerable<TEntity>> GetAsync() => await table.ToListAsync();
        
        public virtual async Task<TEntity> GetByIdAsync(int id)
        {
            TEntity entity = null;
            if (DistributedCache.GetAsync(id.ToString())==null)
            {
                entity = await table.FindAsync(id);
                if (entity == null)
                {
                    throw new EntityNotFoundException(GetEntityNotFoundErrorMessage(id));
                }
                await DistributedCache.SetStringAsync(id.ToString(), JsonConvert.SerializeObject(entity), new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10)
                });
                return entity;

            }
            else
            {
                entity = JsonConvert.DeserializeObject<TEntity>(await DistributedCache.GetStringAsync(id.ToString()));
            }
            return entity;
            
        }
        //
        public abstract Task<TEntity> GetCompleteEntityAsync(int id);
        //
        public virtual async Task InsertAsync(TEntity entity) {
            await table.AddAsync(entity);
            var id = entity.GetType().GetProperty("Id").GetValue(entity);
            await DistributedCache.SetStringAsync(id.ToString(), JsonConvert.SerializeObject(entity), new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10)
            });
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            await Task.Run(() => table.Update(entity));
            var id = entity.GetType().GetProperty("Id").GetValue(entity);
            await DistributedCache.SetStringAsync(id.ToString(), JsonConvert.SerializeObject(entity), new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10)
            });
        }
        public virtual async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            table.Remove(entity);
            if (await DistributedCache.GetStringAsync(id.ToString()) != null)
            {
               await DistributedCache.RemoveAsync(id.ToString());
            }
        }

        protected static string GetEntityNotFoundErrorMessage(int id) =>
            $"{typeof(TEntity).Name} with id {id} not found.";

        public GenericRepository(UnitContext databaseContext,IDistributedCache DistributedCache)
        {
            this.databaseContext = databaseContext;
            table = this.databaseContext.Set<TEntity>();
            this.DistributedCache = DistributedCache;
        }
    }
}
