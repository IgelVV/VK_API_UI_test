using L2Veshkin5.Utilities;
using RestSharp;

namespace L2Veshkin5.VkAPI
{
    public class VkAPI
    {
        private readonly RestClient _client = new(ConfigManager.APIUrlMethod);
        
        public RestResponse PostToCreateWallPost()
        {
            var request = new RestRequest(APIEndpoints.WALL_POST);

            var parameters = new {
                access_token = ConfigManager.Token,
                owner_id = ConfigManager.Id,
                message = RandomUtils.GenerateString(),
                v = ConfigManager.APIVersion
            };

            request.AddObject(parameters);

            var response = _client.Post(request);
            return response;
        }


    }
}
