using L2Veshkin5.Utilities;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using RestSharp.Serializers;
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

            var response = _client.Post(request);
            var postId = (int)JObject.Parse(response.Content)["response"]["post_id"]; //to models
            return postId;
        }

        public int PostToEditWall(int postId)
        {
            var mediaId = SaveWallPhoto();

            var request = new RestRequest(APIEndpoints.WALL_EDIT);

            var parameters = new
            {
                access_token = ConfigManager.Token,
                owner_id = ConfigManager.UserId,
                post_id = postId,
                message = RandomUtils.GenerateString(),
                attachments = $"photo{ConfigManager.UserId}_{mediaId}",
                v = ConfigManager.APIVersion
            };

            request.AddObject(parameters);
            _client.Post(request);

            return mediaId;
        }

        private int SaveWallPhoto()
        {
            var uploadedPhoto = UploadPhoto();

            var request = new RestRequest(APIEndpoints.PHOTOS_SAVE_WALL_PHOTO);
            var parameters = new
            {
                access_token = ConfigManager.Token,
                user_id = ConfigManager.UserId,
                v = ConfigManager.APIVersion,
                server = (int)JObject.Parse(uploadedPhoto.Content)["server"],
                hash = JObject.Parse(uploadedPhoto.Content)["hash"].ToString(),
                photo = JObject.Parse(uploadedPhoto.Content)["photo"].ToString()
            };
            request.AddObject(parameters);

            var response = _client.Post(request);
            var photoId = (int)JObject.Parse(response.Content)["response"][0]["id"];
            return photoId;
        }

        private RestResponse UploadPhoto()
        {
            var uploadServer = GetWallUploadServer();
            var client = new RestClient(uploadServer);
            var request = new RestRequest();
            request.AddFile("photo", ConfigManager.TestPhotoPath, contentType: "multipart/form-data");
            var response = client.Post(request);
            return response;
        }

        private string GetWallUploadServer()
        {
            var request = new RestRequest(APIEndpoints.PHOTOS_GET_WALL_UPLOAD_SERVER);
            var parameters = new
            {
                access_token = ConfigManager.Token,
                v = ConfigManager.APIVersion
            };
            request.AddObject(parameters);

            var response = _client.Post(request);
            var uploadUrl = JObject.Parse(response.Content)["response"]["upload_url"].ToString();
            return uploadUrl;
        }

        public int PostToCreateComment(int postId)
        {
            var text = RandomUtils.GenerateString();
            var request = new RestRequest(APIEndpoints.WALL_CREATE_COMMENT);

            var parameters = new
            {
                access_token = ConfigManager.Token,
                owner_id = ConfigManager.UserId,
                post_id = postId,
                message = text,
                v = ConfigManager.APIVersion
            };
            request.AddObject(parameters);

            var response = _client.Post(request);
            var commentId = (int)JObject.Parse(response.Content)["response"]["comment_id"]; //to models
            return commentId;
        }
    }
}