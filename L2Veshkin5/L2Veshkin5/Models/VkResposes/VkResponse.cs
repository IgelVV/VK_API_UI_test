using System.Text.Json.Serialization;

namespace L2Veshkin5.Models.VkResposes
{
    public class VkResponse
    {
        [JsonPropertyName("response")]
        public Response Response { get; set; }
    }

    public class Response
    {
        //GetUploadServer
        [JsonPropertyName("album_id")]
        public int AlbumId { get; set; }
        [JsonPropertyName("upload_url")]
        public string UploadUrl { get; set; }
        [JsonPropertyName("user_id")]
        public int UserId { get; set; }

        //WallPosr
        [JsonPropertyName("post_id")]
        public int PostId { get; set; }

        //LikesGetList
        [JsonPropertyName("count")]
        public int Count { get; set; }
        [JsonPropertyName("items")]
        public int[] Items { get; set; }

        //SaveWallPhoto
        [JsonPropertyName("id")]
        public int Id { get; set; }

        //CreateComment
        [JsonPropertyName("comment_id")]
        public int CommentId { get; set; }
        [JsonPropertyName("parents_stack")]
        public object[] ParentsStack { get; set; }
    }
}