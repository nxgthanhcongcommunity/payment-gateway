namespace Core.Models.ResponseModels
{
    public class BaseResonse<T> : BaseResonseModel<T>
    {
        public string TraceId { get; set; }
    }
}
