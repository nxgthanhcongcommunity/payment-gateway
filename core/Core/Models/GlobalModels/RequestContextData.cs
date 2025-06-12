namespace Core.Models.GlobalModels
{
    public class RequestContextData
    {
        public string Locale { get; set; } = TZEnum.VN;
        public DateTime CurrentDateTime
        {
            get
            {
                switch (Locale)
                {
                    case TZEnum.VN: return CurrentUTCDateTime.AddHours(7);
                    default: return CurrentUTCDateTime;
                }
            }
        }
        public DateTime CurrentUTCDateTime
        {
            get
            {
                return DateTime.UtcNow;
            }
        }

        public string TraceId 
        { 
            get 
            {
                string guid = Guid.NewGuid().ToString();
                string currentTime = CurrentDateTime.ToString("yyyy-MM-dd-HH:mm:ss.fff");
                return $"[{currentTime}]-{guid}";
            } 
        }

    }

    public static class TZEnum
    {
        public const string VN = "VN";
    }

}
