namespace Core.Models.ResponseModels
{
    public class BaseResonseModel<T>
    {
        public bool Succeed { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
