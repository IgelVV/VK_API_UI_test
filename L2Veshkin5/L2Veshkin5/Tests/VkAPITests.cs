using Aquality.Selenium.Browsers;
using L2Veshkin5.Forms;
using L2Veshkin5.Utilities;
using L2Veshkin5.VkAPI;

namespace L2Veshkin5.Tests
{
    public class VkAPITests: BaseTest
    {
        // как использовать multipart/form-data
        // Чем заголовки отличаются от параметров (в запросах) как указать заголовок в RestSharp?
        // "photo" + {owner_id} + "_" + {photo_id} где взять photo_id? после save
        


        [Test(Description = "TestMyPageFunctionality")]
        public void TestMyPageFunctionality()
        {
            var vkApiRequest = new VkAPI.VkAPI();

            WelcomePage.ClearAndTypeLogin();
            WelcomePage.ClickSignInButton();
            EnterPasswordForm.ClearAndTypePassword();
            EnterPasswordForm.ClickContinueButton();
            SideBarForm.ClickMyProfileButton();

            var textToPost = RandomUtils.GenerateString();
            var postId = vkApiRequest.PostToCreateWallPost(textToPost);
            PostForm createdPost = MyProfileForm.GetPostById(postId);
            var textFromCreatedPost = createdPost.GetPostText();
            var id = createdPost.GetAuthorId();

            Assert.That(textToPost, Is.EqualTo(textFromCreatedPost), "Text doesn't match the one sent.");
            Assert.That(id, Is.EqualTo(ConfigManager.UserId), "Id doesn't match.");

            var photoId = vkApiRequest.PostToEditWall(postId);
            AqualityServices.ConditionalWait.WaitFor(() => !createdPost.GetPostText().Equals(textFromCreatedPost));
            var textFromEditedPost = createdPost.GetPostText();
            var pictureIdFromEditedPost = createdPost.GetPictureId();
            Assert.That(textFromCreatedPost, Is.Not.EqualTo(textFromEditedPost), "Text hasn't changed.");
            Assert.That(pictureIdFromEditedPost.Equals(photoId), "Picture is not the same.");
        }
    }
}