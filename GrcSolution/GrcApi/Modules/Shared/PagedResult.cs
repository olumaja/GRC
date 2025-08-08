namespace GrcApi.Modules.Shared
{
    public abstract class PagedResultBase
    {
        public int CurrentPage { get; set; }

        /// <summary>
        /// Resulting total number of pages factoring RowCount and PageSize
        /// </summary>
        public int PageCount { get; set; }

        /// <summary>
        /// Number of items per page specified by caller
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Total number of records from DB
        /// </summary>
        public int RowCount { get; set; }

        public int FirstRowOnPage
        {
            get { return (CurrentPage - 1) * PageSize + 1; }
        }

        public int LastRowOnPage
        {
            get { return Math.Min(CurrentPage * PageSize, RowCount); }
        }
    }

    public class PagedResult<T> : PagedResultBase where T : class
    {
        public IList<T> Results { get; set; }

        public PagedResult()
        {
            Results = new List<T>();
        }
    }
}
