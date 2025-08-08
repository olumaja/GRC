namespace GrcApi.Modules.Shared.RestHelper
{
    public class Result<T>
    {
        public T Content { get; set; }
        public string Message { get; set; }
        public bool IsSuccess { get; set; } = false;
        public string StatusCode { get; set; }
    }
}
