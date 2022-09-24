using System.Text.Json.Serialization;

namespace AspCoreBE.Selectors
{
    public class UserSelector
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
    }
}
