namespace AspCoreBE.WebCoreSettings
{
    public interface IWebCoreSettings
    {
        string[] AllowedCorsDomains { get; set; }
    }

    public class WebCoreSettings : IWebCoreSettings
    {
        public string[] AllowedCorsDomains { get; set; }
    }
}
