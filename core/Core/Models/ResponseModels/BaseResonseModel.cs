namespace Core.Models.ResponseModels
{
    public class BaseResonseModel<T>
    {
        public bool Succeed { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public object ErrorInfo { get; set; }

        public static BaseResonseModel<T> Success(T data) 
        { 
            return new BaseResonseModel<T> 
            { 
                Succeed = true,
                Data = data,
            };
        }
    }
}
