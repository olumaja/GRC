using Arm.GrcApi.Models;
using Arm.GrcApi.Modules.Shared;

using GrcApi.Modules.Shared;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Arm.GrcTool.Infrastructure
{
    public class Repository<T> : IRepository<T> where T : AuditEntity
    {
        private readonly GrcToolDbContext context;
        internal DbSet<T> dbSet;

        public Repository(GrcToolDbContext context)
        {
            this.context = context;
            dbSet = this.context.Set<T>();
        }
        public async Task AddAsync(T entity)
        {
            await dbSet.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await dbSet.AddRangeAsync(entities);
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return await dbSet.FirstOrDefaultAsync(predicate);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }

        public IQueryable<T> GetAll()
        {
            return dbSet;
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await dbSet.FindAsync(id);
        }

        public IQueryable<T> GetContextByConditon(Expression<Func<T, bool>> predicate)
        {
            return dbSet.Where(predicate);
        }

        public void BulkDelete(Expression<Func<T, bool>> predicate)
        {
            dbSet.Where(predicate).ExecuteDelete();
        }

        public void BulkUpdate(IEnumerable<T> entities)
        {
            dbSet.BulkUpdate(entities);
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
        }

        public void Update(T entity)
        {
            entity.SetModifiedOnUtc(DateTime.Now);
            dbSet.Update(entity);
        }

        public void UpdateRange(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                entity.SetModifiedOnUtc(DateTime.Now);
            }
            dbSet.UpdateRange(entities);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await context.SaveChangesAsync();
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            dbSet.AddRange(entities);
        }

        public int SaveChanges()
        {
            return context.SaveChanges();
        }

        /// <summary>
        /// Get paginated list of the entity
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<List<T>> GetAllPagedAsync(int pageNumber, int pageSize)
        {
            IQueryable<T> query = dbSet;
            if (pageNumber == 0) pageNumber = 1;
            if (pageSize == 0) pageSize = 10;

            var skip = (pageNumber - 1) * pageSize;
            return await query.Skip(skip).Take(pageSize).ToListAsync();
        }

        /// <summary>
        /// Returns a paginated data as another Type (U) as specified in mappingFunc
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <param name="mappingFunc"></param>
        /// <returns>Task</returns>
        public async Task<PagedResult<U>> GetAllPagedAsync<U>(int pageNumber, int pageSize, Func<IQueryable<T>, IQueryable<U>> mappingFunc) where U : class
        {
            IQueryable<T> query = dbSet;
            if (pageNumber == 0) pageNumber = 1;
            if (pageSize == 0) pageSize = 10;

            var result = new PagedResult<U>
            {
                CurrentPage = pageNumber,
                PageSize = pageSize,
                RowCount = query.Count()
            };

            var pageCount = (double)result.RowCount / pageSize;
            result.PageCount = (int)Math.Ceiling(pageCount);

            var skip = (pageNumber - 1) * pageSize;
            result.Results = await mappingFunc(query.Skip(skip).Take(pageSize)).ToListAsync();

            return result;
        }

        /// <summary>
        /// Returns a paginated data as another Type (U) as specified in mappingFunc
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <param name="mappingFunc"></param>
        /// <returns></returns>
        public PagedResult<U> GetAllPaged<U>(int pageNumber, int pageSize, Func<IQueryable<T>, IEnumerable<U>> mappingFunc) where U : class
        {
            IQueryable<T> query = dbSet;
            if (pageNumber == 0) pageNumber = 1;
            if (pageSize == 0) pageSize = 10;

            var result = new PagedResult<U>
            {
                CurrentPage = pageNumber,
                PageSize = pageSize,
                RowCount = query.Count()
            };

            var pageCount = (double)result.RowCount / pageSize;
            result.PageCount = (int)Math.Ceiling(pageCount);

            var skip = (pageNumber - 1) * pageSize;
            result.Results = mappingFunc(query.Skip(skip).Take(pageSize)).ToList();

            return result;
        }
    }
}
