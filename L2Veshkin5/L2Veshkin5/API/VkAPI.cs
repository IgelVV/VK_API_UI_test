using L2Veshkin5.Constants;
using L2Veshkin5.Models.VkResposes;
using L2Veshkin5.Utilities;
using RestSharp;

namespace L2Veshkin5.API
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
                attachments = $"{VkTypes.PHOTO}{ConfigManager.UserId}_{mediaId}",
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
                server = uploadedPhoto.Server,
                hash = uploadedPhoto.Hash,
                photo = uploadedPhoto.Photo
            };
            request.AddObject(parameters);

            var response = _client.Post<VkResponseSaveWallPhoto>(request);
            var photoId = response.Response[0].Id;
            return photoId;
        }

        private ResponseFromUploadServer UploadPhoto()
        {
            var uploadServer = GetWallUploadServer();
            var client = new RestClient(uploadServer);
            var request = new RestRequest();
            request.AddFile("photo", ConfigManager.TestPhotoPath, contentType: "multipart/form-data");
            var response = client.Post<ResponseFromUploadServer>(request);
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

            var response = _client.Post<VkResponse>(request);
            var uploadUrl = response.Response.UploadUrl;
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

            var response = _client.Post<VkResponse>(request);
            var commentId = response.Response.CommentId;
            return commentId;
        }

        public int[] GetUsersWhoPutLikeUderPost(int postId)
        {
            var request = new RestRequest(APIEndpoints.LIKES_GET_LIST);

            var parameters = new
            {
                access_token = ConfigManager.Token,
                type = VkTypes.POST,
                item_id = postId,
                v = ConfigManager.APIVersion
            };
            request.AddObject(parameters);

            var response = _client.Post<VkResponse>(request);
            var usersWhoPutLike = response.Response.Items;
            return usersWhoPutLike;
        }

        public void DeletePost(int postId)
        {
            var request = new RestRequest(APIEndpoints.WALL_DELETE);

            var parameters = new
            {
                access_token = ConfigManager.Token,
                owner_id = ConfigManager.UserId,
                post_id = postId,
                v = ConfigManager.APIVersion
            };
            request.AddObject(parameters);

            _client.Post(request);
        }
    }
}