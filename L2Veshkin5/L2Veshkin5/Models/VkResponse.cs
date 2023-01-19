using System.Text.Json.Serialization;

namespace L2Veshkin5.Models
{
    public class VkResponse
    {
        [JsonPropertyName("response")]
        public Response Response { get; set; }
    }

    public class Response
    {
        [JsonPropertyName("post_id")]
        public int PostId { get; set; }
    }
}