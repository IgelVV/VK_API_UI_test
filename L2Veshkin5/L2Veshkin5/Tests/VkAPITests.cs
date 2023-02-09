using Aquality.Selenium.Browsers;
using L2Veshkin5.API;
using L2Veshkin5.Forms;
using L2Veshkin5.Utilities;

namespace L2Veshkin5.Tests
{
    public class VkAPITests: BaseTest
    {
        [Test(Description = "TestMyPageFunctionality")]
        public void TestMyPageFunctionality()
        {
            var vkApi = new VkAPI();

            WelcomePage.ClearAndTypeLogin();
            WelcomePage.ClickSignInButton();
            EnterPasswordForm.ClearAndTypePassword();
            EnterPasswordForm.ClickContinueButton();
            SideBarForm.ClickMyProfileButton();

            string textToPost = RandomUtils.GenerateString();
            int postId = vkApi.PostToCreateWallPost(textToPost);
            PostForm createdPost = MyProfileForm.GetPostById(postId);
            string textFromCreatedPost = createdPost.GetPostText();
            int id = createdPost.GetAuthorOfPostId();

            Assert.That(textToPost, Is.EqualTo(textFromCreatedPost), "Text doesn't match the one sent.");
            Assert.That(id, Is.EqualTo(ConfigManager.UserId), "Id doesn't match.");

            int photoId = vkApi.PostToEditWall(postId);
            AqualityServices.ConditionalWait.WaitFor(() => !createdPost.GetPostText().Equals(textFromCreatedPost));
            string textFromEditedPost = createdPost.GetPostText();
            int pictureIdFromEditedPost = createdPost.GetPictureId();
            Assert.That(textFromCreatedPost, Is.Not.EqualTo(textFromEditedPost), "Text hasn't changed.");
            Assert.That(pictureIdFromEditedPost, Is.EqualTo(photoId), "Picture is not the same.");

            int commentId = vkApi.PostToCreateComment(postId);
            int authorOfCommentId = createdPost.GetAuthorOfCommentId(commentId);
            Assert.That(authorOfCommentId, Is.EqualTo(ConfigManager.UserId), "There are no comments from the right user.");

            createdPost.Like();
            AqualityServices.ConditionalWait.WaitFor(() => createdPost.IsReactionClicked());
            int[] likes = vkApi.GetUsersWhoPutLikeUderPost(postId);
            Assert.That(likes.Contains(ConfigManager.UserId), Is.True, "There are no likes from the right user.");

            vkApi.DeletePost(postId);
            createdPost.State.WaitForDisplayed();
            Assert.That(createdPost.State.IsDisplayed, Is.True, "The post hasn't been deleted.");
        }
    }
}