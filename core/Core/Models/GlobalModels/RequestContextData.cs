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
        public DateTime CurrentUTCDateTime { get; set; }
    }

    public static class TZEnum
    {
        public const string VN = "VN";
    }

}
