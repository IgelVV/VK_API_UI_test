using L2Veshkin5.Models;
using L2Veshkin5.Utilities;
using Newtonsoft.Json.Linq;
using RestSharp;
using static System.Net.Mime.MediaTypeNames;

namespace L2Veshkin5.VkAPI
{
    public class VkAPI
    {
        private readonly RestClient _client = new(ConfigManager.APIUrlMethod);
        
        public int PostToCreateWallPost(string text)
        {
            var request = new RestRequest(APIEndpoints.WALL_POST);

            var parameters = new {
                access_token = ConfigManager.Token,
                owner_id = ConfigManager.UserId,
                message = text,
                v = ConfigManager.APIVersion
            };

            request.AddObject(parameters);

            var response = _client.Post<VkResponse>(request);
            var postId = response.Response.PostId;
            return postId;
        }

        public void PostToEditWall(int postId) // downloading photo
        {
            var request = new RestRequest(APIEndpoints.WALL_EDIT);

            var parameters = new {
                access_token = ConfigManager.Token,
                owner_id = ConfigManager.UserId,
                post_id = postId,
                message = RandomUtils.GenerateString(),
                v = ConfigManager.APIVersion
            };

            request.AddObject(parameters);
            _client.Post(request);
        }


    }
}
