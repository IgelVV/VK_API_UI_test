using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using L2Veshkin5.Constants;
using L2Veshkin5.Extetions;
using L2Veshkin5.Utilities;
using OpenQA.Selenium;
using System.Text.RegularExpressions;

namespace L2Veshkin5.Forms
{
    public class PostForm : Form
    {
        private readonly int _postId;
        private ILabel PostText =>
            FormElement.FindChildElement<ILabel>(By.ClassName("wall_post_text"), $"{nameof(PostText)} {_postId}");
        private IButton PostAuthorButton =>
            FormElement.FindChildElement<IButton>(By.XPath("//*[contains(@class, 'post_author')]/a"), $"{nameof(PostAuthorButton)} {_postId}");
        private ILabel PostPicture => 
            FormElement.FindChildElement<ILabel>(By.XPath("//*[contains(@href,'photo')]"), $"{nameof(PostPicture)} {_postId}");
        private IButton ShowNextRepliesButton =>
            FormElement.FindChildElement<IButton>(By.ClassName("js-replies_next_label"), $"{nameof(ShowNextRepliesButton)} {_postId}");
        private IButton ReactionsButton =>
            FormElement.FindChildElement<IButton>(By.ClassName("PostButtonReactions-"), $"{nameof(ReactionsButton)} {_postId}");

        private IButton AuthorOfComment(int commentId) =>
            FormElement.FindChildElement<IButton>(By.XPath($"//*[@id='post{ConfigManager.UserId}_{commentId}']//*[contains(@class, 'reply_author')]/a"), $"{nameof(AuthorOfComment)}{commentId} {_postId}");

        public PostForm(int postId): base (By.Id($"post{ConfigManager.UserId}_{postId}"), $"{nameof(PostForm)} {postId}") 
        {
            _postId = postId;
        }

        public string GetPostText() => PostText.Text;

        public int GetAuthorOfPostId() => GetIdFromElementHref(PostAuthorButton);

        public int GetPictureId() => GetIdFromElementHref(PostPicture);

        private int GetIdFromElementHref(IElement element)
        {
            var pattern = new Regex(@"\d+$");
            var value = pattern.Match(element.GetHref()).Value;
            int id = int.Parse(value);
            return id;
        }

        public int GetAuthorOfCommentId(int commentId)
        {
            if (ShowNextRepliesButton.State.WaitForExist())
            {
                ShowNextRepliesButton.JsActions.ScrollToTheCenter();
                ShowNextRepliesButton.Click();
            };
            var authorOfComment = AuthorOfComment(commentId);
            var authorId = int.Parse(authorOfComment.GetAttribute(HtmlAttributes.DATA_FROM_ID));
            return authorId;
        }

        public void Like()
        {
            ReactionsButton.JsActions.ScrollToTheCenter();
            ReactionsButton.Click();
        }

        public bool IsReactionClicked() 
        {
            return ReactionsButton.GetAttribute(HtmlAttributes.DATA_REACTION_USER_REACTION_ID) is not null;
        }
    }
}