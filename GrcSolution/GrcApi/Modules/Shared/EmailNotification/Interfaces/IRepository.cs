using GrcApi.Modules.Shared;

using System.Linq.Expressions;

namespace Arm.GrcTool.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        IQueryable<T> GetAll();
        Task<T> GetByIdAsync(Guid id);
        IQueryable<T> GetContextByConditon(Expression<Func<T, bool>> predicate);
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
        Task AddAsync(T entity);
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        Task AddRangeAsync(IEnumerable<T> entities);
        void Update(T entity);
        void BulkUpdate(IEnumerable<T> entities);
        void UpdateRange(IEnumerable<T> entities);

        void BulkDelete(Expression<Func<T, bool>> predicate);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        Task<int> SaveChangesAsync();
        int SaveChanges();
        Task<List<T>> GetAllPagedAsync(int pageNumber, int pageSize);
        Task<PagedResult<U>> GetAllPagedAsync<U>(int pageNumber, int pageSize, Func<IQueryable<T>, IQueryable<U>> mappingFunc) where U : class;
        /// <summary>
        /// Returns a paginated data as another Type (U) as specified in mappingFunc
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <param name="mappingFunc"></param>
        /// <returns></returns>
        PagedResult<U> GetAllPaged<U>(int pageNumber, int pageSize, Func<IQueryable<T>, IEnumerable<U>> mappingFunc) where U : class;
    }
}
