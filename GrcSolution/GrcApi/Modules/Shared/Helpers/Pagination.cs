using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace GrcApi.Modules.Shared.Helpers
{
    public class Pagination<T> : List<T>
    {
        public int CurrentPage { get; private set; }
        public int TotalPages { get; private set; }
        public int PageSize { get; private set; }
        public int TotalCount { get; private set; }
        public bool HasPreviousPage => (CurrentPage > 1);
        public bool HasNextPage => (CurrentPage < TotalPages);

        public Pagination(List<T> items, int totalCount, int pageNumber, int pageSize) { 
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalCount = totalCount;
            TotalPages = Convert.ToInt32(Math.Ceiling(totalCount / (double)pageSize));
            AddRange(items);
        }
               
        public static Pagination<T> Create(IQueryable<T> collections, int pageNumber, int pageSize)
        {
            var totalCount = collections.Count();
            var items = collections.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            return new Pagination<T>(items, totalCount, pageNumber, pageSize);
        }
    }

    public static class PaginationHeader
    {
        public static void AddPagination(this HttpResponse response, PaginationMeta meta)
        {
            var camelCaseFormat = new JsonSerializerSettings();
            camelCaseFormat.ContractResolver = new CamelCasePropertyNamesContractResolver();
            response.Headers.Add("Access-Control-Expose-Headers", "X-Pagination");
            response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(meta, camelCaseFormat));
        }
    }

    public record PaginationMeta (
         bool HasNextPage,
         bool HasPreviousPage,
         int CurrentPage,
         int PageSize,
         int TotalPages,
         int TotalCount
    );

    public class PaginationV2<T> : List<T>
    {
        public int? CurrentPage { get; private set; }
        public int? TotalPages { get; private set; }
        public int? PageSize { get; private set; }
        public int? TotalCount { get; private set; }
        public bool? HasPreviousPage => (CurrentPage > 1);
        public bool HasNextPage => (CurrentPage < TotalPages);

        public PaginationV2(List<T> items, int totalCount, int? pageNumber, int? pageSize)
        {
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalCount = totalCount;
            TotalPages = Convert.ToInt32(Math.Ceiling(totalCount / (double)pageSize));
            AddRange(items);
        }

        public static PaginationV2<T> Create(IQueryable<T> collections, int pageNumber, int pageSize)
        {
            var totalCount = collections.Count();
            var items = collections.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            return new PaginationV2<T>(items, totalCount, pageNumber, pageSize);
        }
    }
}

