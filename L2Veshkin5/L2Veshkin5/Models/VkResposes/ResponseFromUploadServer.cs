using System.Text.Json.Serialization;

namespace L2Veshkin5.Models.VkResposes
{
    public class ResponseFromUploadServer
    {
        [JsonPropertyName("server")]
        public int Server { get; set; }
        [JsonPropertyName("photo")]
        public string Photo { get; set; }
        [JsonPropertyName("hash")]
        public string Hash { get; set; }
    }
}
