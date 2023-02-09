using System.Text.Json.Serialization;

namespace L2Veshkin5.Models.VkResposes
{
    public class VkResponseSaveWallPhoto
    {
        [JsonPropertyName("response")]
        public Response[] Response { get; set; }
    }
}
