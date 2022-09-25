namespace AspCoreBE.WebCoreSettings
{
    public interface IWebCoreSettings
    {
        string[] AllowedCorsDomains { get; set; }

        string DbConnectionString { get; set; }
    }

    public class WebCoreSettings : IWebCoreSettings
    {
        public string[] AllowedCorsDomains { get; set; }

        public string DbConnectionString { get; set; }

        public WebCoreSettings()
        {
            AllowedCorsDomains = new string[0];
            DbConnectionString = "";
        }
    }
}
