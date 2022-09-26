using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AspCoreBE.Models
{
    [Table("tblUser")]
    public class UserModel : BaseModel
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }
    }
}
